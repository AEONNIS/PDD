using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private List<PlayerStatsRecord> _records = new List<PlayerStatsRecord>();

    private string _fileName = "PlayerStats.json";
    private string _filePath;

    private void Awake()
    {
        _filePath = $"{Application.dataPath}/{_fileName}";
        Load();
    }

    public void AddRecords(GameResult result, float signsPlacementTime, float choicePrioritiesTime)
    {
        _records.Add(new PlayerStatsRecord(result, DateTime.Now, signsPlacementTime, choicePrioritiesTime));
        Save();
    }

    public void Clear()
    {
        _records = new List<PlayerStatsRecord>();
        Save();
    }

    public PlayerStatsResults CalculateTotalResults()
    {
        return CalculateResults(_records);
    }

    public PlayerStatsResults CalculateResultsForLastDays(int numberLastDays)
    {
        IEnumerable<PlayerStatsRecord> records = SelectRecordsForLastDays(numberLastDays);
        return CalculateResults(records);
    }

    private PlayerStatsResults CalculateResults(IEnumerable<PlayerStatsRecord> records)
    {
        return new PlayerStatsResults(GetAmounts(records), GetAverageTimes(records.Where(record => record.Result == GameResult.Win)));
    }

    private void Load()
    {
        if (File.Exists(_filePath))
            JsonUtility.FromJsonOverwrite(File.ReadAllText(_filePath), this);
    }

    private void Save()
    {
        File.WriteAllText(_filePath, JsonUtility.ToJson(this));
    }

    private IEnumerable<PlayerStatsRecord> SelectRecordsForLastDays(int numberLastDays)
    {
        DateTime lastFewDaysAgo = DateTime.Now - new TimeSpan(numberLastDays, 0, 0, 0);
        return _records.Where(record => record.Date >= lastFewDaysAgo);
    }

    private PlayerStatsAmounts GetAmounts(IEnumerable<PlayerStatsRecord> records)
    {
        if (records.Count() == 0)
        {
            return new PlayerStatsAmounts(0, 0, 0, 0, 0);
        }
        else
        {
            int amountWins = records.Where(record => record.Result == GameResult.Win).Count();
            int amountLosses = records.Where(record => record.Result != GameResult.Win).Count();
            int amountTimeIsOverLosses = records.Where(record => record.Result == GameResult.TimeIsOverLoss).Count();
            int amountWrongAnswerLosses = records.Where(record => record.Result == GameResult.WrongAnswerLoss).Count();

            return new PlayerStatsAmounts(records.Count(), amountWins, amountLosses, amountTimeIsOverLosses, amountWrongAnswerLosses);
        }
    }

    private PlayerStatsAverageTimes GetAverageTimes(IEnumerable<PlayerStatsRecord> records)
    {
        if (records.Count() == 0)
        {
            return new PlayerStatsAverageTimes(0, 0, 0);
        }
        else
        {
            float totalGameTime = 0.0f;
            float totalSignsPlacementTime = 0.0f;
            float totalChoicePrioritiesTime = 0.0f;

            foreach (var record in records)
            {
                totalGameTime += record.GameTime;
                totalSignsPlacementTime += record.SignsPlacementTime;
                totalChoicePrioritiesTime += record.ChoicePrioritiesTime;
            }

            return new PlayerStatsAverageTimes(totalGameTime / records.Count(),
                                               totalSignsPlacementTime / records.Count(),
                                               totalChoicePrioritiesTime / records.Count());
        }
    }
}
