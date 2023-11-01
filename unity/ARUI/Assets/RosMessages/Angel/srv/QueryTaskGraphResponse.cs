//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Angel
{
    [Serializable]
    public class QueryTaskGraphResponse : Message
    {
        public const string k_RosMessageName = "angel_msgs/QueryTaskGraph";
        public override string RosMessageName => k_RosMessageName;

        //  Response
        //  List of task titles to monitor
        public string[] task_titles;
        //  List of TaskGraphs - must be equal in length to `task_titles`
        public TaskGraphMsg[] task_graphs;

        public QueryTaskGraphResponse()
        {
            this.task_titles = new string[0];
            this.task_graphs = new TaskGraphMsg[0];
        }

        public QueryTaskGraphResponse(string[] task_titles, TaskGraphMsg[] task_graphs)
        {
            this.task_titles = task_titles;
            this.task_graphs = task_graphs;
        }

        public static QueryTaskGraphResponse Deserialize(MessageDeserializer deserializer) => new QueryTaskGraphResponse(deserializer);

        private QueryTaskGraphResponse(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.task_titles, deserializer.ReadLength());
            deserializer.Read(out this.task_graphs, TaskGraphMsg.Deserialize, deserializer.ReadLength());
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.WriteLength(this.task_titles);
            serializer.Write(this.task_titles);
            serializer.WriteLength(this.task_graphs);
            serializer.Write(this.task_graphs);
        }

        public override string ToString()
        {
            return "QueryTaskGraphResponse: " +
            "\ntask_titles: " + System.String.Join(", ", task_titles.ToList()) +
            "\ntask_graphs: " + System.String.Join(", ", task_graphs.ToList());
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize, MessageSubtopic.Response);
        }
    }
}
