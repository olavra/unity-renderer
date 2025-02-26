﻿using System;
using System.Collections.Generic;

namespace DCL
{
    public interface IMessagingControllersManager : IService
    {
        bool hasPendingMessages { get; }
        bool isRunning { get; }
        bool paused { get; set; }
        int pendingInitMessagesCount { get; set; }
        long processedInitMessagesCount { get; set; }
        int pendingMessagesCount { get; set; }
        void MarkBusesDirty();
        void PopulateBusesToBeProcessed();
        bool ContainsController(string sceneId);
        void AddController(IMessageProcessHandler messageHandler, string sceneId, bool isGlobal = false);
        void AddControllerIfNotExists(IMessageProcessHandler messageHandler, string sceneId, bool isGlobal = false);
        void RemoveController(string sceneId);
        void Enqueue(bool isUiBus, QueuedSceneMessage_Scene queuedMessage);
        void ForceEnqueueToGlobal(MessagingBusType busId, QueuedSceneMessage queuedMessage);
        void SetSceneReady(string sceneId);
    }
}