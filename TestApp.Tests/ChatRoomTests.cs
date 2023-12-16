using NUnit.Framework;
using TestApp.Chat;

namespace TestApp.Tests
{
    [TestFixture]
    public class ChatRoomTests
    {
        private ChatRoom _chatRoom;

        [SetUp]
        public void Setup()
        {
            this._chatRoom = new ChatRoom();
        }

        [Test]
        public void Test_SendMessage_MessageSentToChatRoom()
        {
            // Arrange
            string sender = "User1";
            string message = "Hello, how are you?";

            // Act
            _chatRoom.SendMessage(sender, message);

            // Assert
            StringAssert.Contains($"{sender}: {message}", _chatRoom.DisplayChat());
        }


        [Test]
        public void Test_DisplayChat_NoMessages_ReturnsEmptyString()
        {
            // Act
            string result = _chatRoom.DisplayChat();

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void Test_DisplayChat_WithMessages_ReturnsFormattedChat()
        {
            // Arrange
            string sender1 = "User1";
            string message1 = "Hello, how are you?";
            string sender2 = "User2";
            string message2 = "I'm good, thanks!";

            // Act
            _chatRoom.SendMessage(sender1, message1);
            _chatRoom.SendMessage(sender2, message2);

            // Assert
            StringAssert.Contains($"{sender1}: {message1}", _chatRoom.DisplayChat());
            StringAssert.Contains($"{sender2}: {message2}", _chatRoom.DisplayChat());
        }
    }
}
