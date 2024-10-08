//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Angel
{
    [Serializable]
    public class AruiUpdateMsg : Message
    {
        public const string k_RosMessageName = "angel_msgs/AruiUpdate";
        public override string RosMessageName => k_RosMessageName;

        // 
        //  Message encapsulating a monolithic update to send back to the AR-UI so it may
        //  be able to update it's user-facing rendering appropriately, and provide the
        //  appropriate signaling.
        // 
        //  This should broadly include:
        //    * 3D object updates
        //    * 3D activity updates
        //    * task graph summary
        //    * current task state
        //    * New error messages
        //    *
        // 
        //  NOTE: This message is initially in a state of "drafting" out what the ARUI
        //  needs, so some aspects are over-specified in this message and may be more
        //  appropriately broken out into a separate message file.
        // 
        //  meeting notes:
        //  provide goals / trying to accomplish, but not specifically what to do
        //  want to also know where all virtual things -- ARUI produces/manages these?
        //  probably want to also add spatial bounds to activity messages
        // 
        // 
        public Std.HeaderMsg header;
        // 
        //  3D Objects
        // 
        //  These objects represent incremental updates and removals to 3D objects that
        //  the system has observed. Objects have a UID to reflect entity persistence as
        //  determined by the system. If an object does not receive any updates, we
        //  expect that to be interpreted that they object still exists as the same as
        //  the last update.
        // 
        //  NOTE: All objects may be retrieved in batch by using the
        //  `angel_msgs/QueryAllObjects3d` service.
        // 
        //  Array of 3D objects that explicitly do not exist. UIDs are "reclaimed" in
        //  that new objects may re-use old UIDs.
        public AruiObject3dMsg[] object3d_remove;
        //  Existing or new objects whose state has changed in some way.
        public AruiObject3dMsg[] object3d_update;
        // 
        //  Activities
        // 
        public ActivityDetectionMsg latest_activity;
        // 
        //  User modeling
        // 
        //  This is probably more a reminder that user-modeling info will come in through
        //  this channel.
        // 
        public byte expertise_level;
        // 
        //  Task Graph and State
        // 
        //  Message representing the current status of the task being performed.
        // 
        //  NOTE: The task graph may be queried by using the `QueryTaskGraph` service.
        // 
        public TaskUpdateMsg task_update;
        // 
        //  User Communications
        // 
        //  Broad category of information that should be conveyed to a user.
        //  Different categories of communications have their own messages.
        // 
        //  Notifications / Directives
        public AruiUserNotificationMsg[] notifications;
        //  Field encapsulating interpreted user intents that we want confirmed by the user.
        //  These likely have some confidence less than
        public InterpretedAudioUserIntentMsg[] intents_for_confirmation;

        public AruiUpdateMsg()
        {
            this.header = new Std.HeaderMsg();
            this.object3d_remove = new AruiObject3dMsg[0];
            this.object3d_update = new AruiObject3dMsg[0];
            this.latest_activity = new ActivityDetectionMsg();
            this.expertise_level = 0;
            this.task_update = new TaskUpdateMsg();
            this.notifications = new AruiUserNotificationMsg[0];
            this.intents_for_confirmation = new InterpretedAudioUserIntentMsg[0];
        }

        public AruiUpdateMsg(Std.HeaderMsg header, AruiObject3dMsg[] object3d_remove, AruiObject3dMsg[] object3d_update, ActivityDetectionMsg latest_activity, byte expertise_level, TaskUpdateMsg task_update, AruiUserNotificationMsg[] notifications, InterpretedAudioUserIntentMsg[] intents_for_confirmation)
        {
            this.header = header;
            this.object3d_remove = object3d_remove;
            this.object3d_update = object3d_update;
            this.latest_activity = latest_activity;
            this.expertise_level = expertise_level;
            this.task_update = task_update;
            this.notifications = notifications;
            this.intents_for_confirmation = intents_for_confirmation;
        }

        public static AruiUpdateMsg Deserialize(MessageDeserializer deserializer) => new AruiUpdateMsg(deserializer);

        private AruiUpdateMsg(MessageDeserializer deserializer)
        {
            this.header = Std.HeaderMsg.Deserialize(deserializer);
            deserializer.Read(out this.object3d_remove, AruiObject3dMsg.Deserialize, deserializer.ReadLength());
            deserializer.Read(out this.object3d_update, AruiObject3dMsg.Deserialize, deserializer.ReadLength());
            this.latest_activity = ActivityDetectionMsg.Deserialize(deserializer);
            deserializer.Read(out this.expertise_level);
            this.task_update = TaskUpdateMsg.Deserialize(deserializer);
            deserializer.Read(out this.notifications, AruiUserNotificationMsg.Deserialize, deserializer.ReadLength());
            deserializer.Read(out this.intents_for_confirmation, InterpretedAudioUserIntentMsg.Deserialize, deserializer.ReadLength());
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.header);
            serializer.WriteLength(this.object3d_remove);
            serializer.Write(this.object3d_remove);
            serializer.WriteLength(this.object3d_update);
            serializer.Write(this.object3d_update);
            serializer.Write(this.latest_activity);
            serializer.Write(this.expertise_level);
            serializer.Write(this.task_update);
            serializer.WriteLength(this.notifications);
            serializer.Write(this.notifications);
            serializer.WriteLength(this.intents_for_confirmation);
            serializer.Write(this.intents_for_confirmation);
        }

        public override string ToString()
        {
            return "AruiUpdateMsg: " +
            "\nheader: " + header.ToString() +
            "\nobject3d_remove: " + System.String.Join(", ", object3d_remove.ToList()) +
            "\nobject3d_update: " + System.String.Join(", ", object3d_update.ToList()) +
            "\nlatest_activity: " + latest_activity.ToString() +
            "\nexpertise_level: " + expertise_level.ToString() +
            "\ntask_update: " + task_update.ToString() +
            "\nnotifications: " + System.String.Join(", ", notifications.ToList()) +
            "\nintents_for_confirmation: " + System.String.Join(", ", intents_for_confirmation.ToList());
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize);
        }
    }
}
