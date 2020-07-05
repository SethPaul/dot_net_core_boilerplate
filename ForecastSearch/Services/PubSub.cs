using Google.Cloud.PubSub.V1;
using Grpc.Core;
using System;
using Google.Protobuf;

namespace ForecastCore.Services
{
    public class CreateTopicSample
    {
        public Topic CreateTopic(string projectId, string topicId)
        {
            PublisherServiceApiClient publisher =
                PublisherServiceApiClient.Create();
            var topicName = TopicName.FromProjectTopic(projectId, topicId);
            Topic topic = null;

            try
            {
                topic = publisher.CreateTopic(topicName);
                Console.WriteLine($"Topic {topic.Name} created.");
            }
            catch (RpcException e) when (e.Status.StatusCode ==
                                         StatusCode.AlreadyExists)
            {
                Console.WriteLine($"Topic {topicName} already exists.");
            }

PubsubMessage message = new PubsubMessage
{
    // The data is any arbitrary ByteString. Here, we're using text.
    Data = ByteString.CopyFromUtf8("Hello, Pubsub"),
    // The attributes provide metadata in a string-to-string dictionary.
    Attributes =
    {
        { "description", "Simple text message" }
    }
};
publisher.Publish(topicName, new[] { message });

            return topic;

        }

        public void PublishMessage(string projectId, string topicId)
        {
            PublisherServiceApiClient publisher =
                PublisherServiceApiClient.Create();
            var topicName = TopicName.FromProjectTopic(projectId, topicId);
PubsubMessage message = new PubsubMessage
{
    // The data is any arbitrary ByteString. Here, we're using text.
    Data = ByteString.CopyFromUtf8("Hello, Pubsub"),
    // The attributes provide metadata in a string-to-string dictionary.
    Attributes =
    {
        { "description", "Simple text message" }
    }
};
publisher.Publish(topicName, new[] { message });


        }
    }
}
