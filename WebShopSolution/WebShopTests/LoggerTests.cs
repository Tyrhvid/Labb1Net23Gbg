using WebShop.Logging;

namespace WebShop.Tests
{
    public class LoggerTests
    {
        [Fact]
        public void FileLogger_ShouldLogMessageToFile()
        {
            // Arrange
            var filePath = "test_log.txt";
            var logger = new FileLogger(filePath);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // Act
            logger.Log("Test message");

            // Assert
            Assert.True(File.Exists(filePath));

            var logContent = File.ReadAllText(filePath);
            Assert.Contains("Test message", logContent);
        }
    }
}