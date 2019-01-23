﻿using MyBasicTaskManager.Models;
using MyBasicTaskManager.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBasicTaskManager.Repositories
{
    public class StatisticsRepository
    {
        private readonly DatabaseModel _db = new DatabaseModel();
        public StatisticsFull Get(string UserId)
        {
            var model = _db.STATISTICS.Where(x => x.USER_ID == UserId).Select(x => new StatisticsFull()
            {
                CreatedTasks = x.CREATED_TASKS,
                FinishedTasks = x.FINISHED_TASKS,
                DeletedTasks = x.DELETED_TASKS,
                TasksWithDeadline = x.TASKS_WITH_DEADLINE,
                TasksFinishedBeforeDeadline = x.TASKS_FINISHED_BEFORE_DEADLINE,
                FirstTaskCreation = x.FIRST_TASK_CREATION,
                LastTaskCreation = x.LAST_TAKS_CREATION
            }).FirstOrDefault();
            return model;
        }
        private void CreateUserRecord(string UserId)
        {
            var model = new STATISTICS()
            {
                USER_ID= UserId,
                CREATED_TASKS = 0,
                FINISHED_TASKS = 0,
                DELETED_TASKS = 0,
                TASKS_WITH_DEADLINE = 0,
                TASKS_FINISHED_BEFORE_DEADLINE = 0,
                FIRST_TASK_CREATION = DateTime.Now,
                LAST_TAKS_CREATION = DateTime.Now
            };
            using (_db)
            {
                _db.STATISTICS.Add(model);
                _db.SaveChanges();
            }
        }
        public void SetCreatedTasks(string UserId)
        {
            using (_db)
            {
                var model = _db.STATISTICS.Where(x => x.USER_ID == UserId).FirstOrDefault();
                if(model==null)
                {
                    CreateUserRecord(UserId);
                    model = _db.STATISTICS.Where(x => x.USER_ID == UserId).FirstOrDefault();
                }
                model.CREATED_TASKS = model.CREATED_TASKS + 1;
                _db.SaveChanges();
            }
        }
        public void SetFinishedTasks(string UserId,int value)
        {
            using (_db)
            {
                var model = _db.STATISTICS.Where(x => x.USER_ID == UserId).FirstOrDefault();
                if (model == null)
                {
                    CreateUserRecord(UserId);
                    model = _db.STATISTICS.Where(x => x.USER_ID == UserId).FirstOrDefault();
                }
                model.FINISHED_TASKS = model.FINISHED_TASKS + value;
                _db.SaveChanges();
            }
        }
        public void SetTasksWithDeadline(string UserId, int value)
        {
            using (_db)
            {
                var model = _db.STATISTICS.Where(x => x.USER_ID == UserId).FirstOrDefault();
                if (model == null)
                {
                    CreateUserRecord(UserId);
                    model = _db.STATISTICS.Where(x => x.USER_ID == UserId).FirstOrDefault();
                }
                model.TASKS_WITH_DEADLINE = model.TASKS_WITH_DEADLINE + value;
                _db.SaveChanges();
            }
        }
        public void SetTasksFinishedBeforeDeadline(string UserId, int value)
        {
            using (_db)
            {
                var model = _db.STATISTICS.Where(x => x.USER_ID == UserId).FirstOrDefault();
                if (model == null)
                {
                    CreateUserRecord(UserId);
                    model = _db.STATISTICS.Where(x => x.USER_ID == UserId).FirstOrDefault();
                }
                model.TASKS_FINISHED_BEFORE_DEADLINE = model.TASKS_FINISHED_BEFORE_DEADLINE + value;
                _db.SaveChanges();
            }
        }
        public void SetLastTaskCreation(string UserId)
        {
            using (_db)
            {
                var model = _db.STATISTICS.Where(x => x.USER_ID == UserId).FirstOrDefault();
                if (model == null)
                {
                    CreateUserRecord(UserId);
                    model = _db.STATISTICS.Where(x => x.USER_ID == UserId).FirstOrDefault();
                }
                model.LAST_TAKS_CREATION = DateTime.Now;
                _db.SaveChanges();
            }
        }
    }
}