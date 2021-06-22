﻿using System;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace hhnl.HomeAssistantNet.Shared.Automation
{
    public class AutomationRunInfo
    {
        private static Action _noop = () => { };

        public string? Error { get; set; }
        
        public DateTimeOffset Started { get; set; }
        
        public DateTimeOffset? Ended { get; set; }
        
        public RunState State { get; set; }

        public StartReason Reason { get; set; }

        public string? ChangedEntity { get; set; }


        [JsonIgnore] 
        public Task Task { get; set; } = Task.CompletedTask;

        [JsonIgnore] 
        public Action Start { get; set; } = _noop;
        
        [JsonIgnore]
        public CancellationTokenSource? CancellationTokenSource { get; set; }
        
        public enum RunState
        {
            Running,
            Completed,
            Cancelled,
            Error,
            WaitingInQueue,
        }
        
        public enum StartReason
        {
            RunOnStart,
            EntityChanged,
            Manual,
        }
    }
}