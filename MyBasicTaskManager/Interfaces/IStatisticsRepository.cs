using MyBasicTaskManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBasicTaskManager.Interfaces
{
    public interface IStatisticsRepository
    {
        StatisticsFull Get(string UserId);
        void SetCreatedTasks(string UserId);
        void SetFinishedTasks(string UserId, int value);
        void SetTasksWithDeadline(string UserId, int value);
        void SetTasksFinishedBeforeDeadline(string UserId, int value);
        void SetLastTaskCreation(string UserId);
        void SetDeletedTasks(string UserId);
        void ClearData(string UserId);
    }
}