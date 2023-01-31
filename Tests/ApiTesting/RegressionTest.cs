using Microsoft.VisualStudio.TestTools.UnitTesting;
using UiandApiTest.Pages.Api.DTO;
using UiandApiTest.Pages.Api;
using UiandApiTest.Utilities.Reporter;

namespace UiandApiTest.Tests.ApiTesting
{
    [TestClass]
    public class RegressionTest
    {
        public TestContext TestContext { get; set; }
        public int numericCode { get; private set; }


        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            var dir = testContext.TestRunDirectory;
            Report.SetUpExtentReport("API Regression Test", "API Regression Test Report", dir);
        }


        [TestInitialize]
        public void SetupTest()
        {
            Report.CreateTest(TestContext.TestName);
        }

        [TestCleanup]
        public void CleanupTest()
        {
            var testStatus = TestContext.CurrentTestOutcome;
            AventStack.ExtentReports.Status logStatus;

            switch (testStatus)
            {
                case UnitTestOutcome.Failed:
                    logStatus = AventStack.ExtentReports.Status.Fail;
                    Report.TestStatus(logStatus.ToString());
                    break;
                case UnitTestOutcome.Inconclusive:
                    break;
                case UnitTestOutcome.Passed:
                    break;
                case UnitTestOutcome.InProgress:
                    break;
                case UnitTestOutcome.Error:
                    break;
                case UnitTestOutcome.Timeout:
                    break;
                case UnitTestOutcome.Aborted:
                    break;
                case UnitTestOutcome.Unknown:
                    break;
                case UnitTestOutcome.NotRunnable:
                    break;
                default:
                    break;
            }
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            Report.FlushReport();
        }

        [TestMethod]
        public void VerifyListOfUsers()
        {
            var demo = new Demo();
            var user = demo.GetUsers("api/users?page=2");
            Assert.AreEqual(2, user.page);
            Report.LogToReport(AventStack.ExtentReports.Status.Pass, "Page number does not match");
            Assert.AreEqual("Michael", user.data[0].first_name);
            Report.LogToReport(AventStack.ExtentReports.Status.Pass, "User first name does not match");

        }

        [DeploymentItem("Utilities\\Api\\Test Data\\TestCase.csv"),
        DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "TestCase.csv", "TestCase#csv",
            DataAccessMethod.Sequential)]
        [TestMethod]
        public void CreateNewUser()
        {
            var users = new CreateUserRequestDTO();
            users.name = TestContext.DataRow["name"].ToString();
            Report.LogToReport(AventStack.ExtentReports.Status.Info, "Test Data for name is " + users.name);
            users.job = TestContext.DataRow["job"].ToString();

            var demo = new Demo();
            var user = demo.CreateUser("api/users", users);
            Assert.AreEqual("Mike", user.name);
            Assert.AreEqual("Lead", user.job);
        }

        [TestMethod]
        public void UpdateNewUser()
        {
            string payload = @"{
                                 ""name"": ""morpheus"",
                                 ""job"": ""zion resident"",
                                 ""updatedAt"": ""2023-01-09T11:52:20.947Z""
                               }";
            var demo = new Demo();
            var user = demo.UpdateUser("api/users/2", payload);
            Assert.AreEqual("morpheus", user.name);
        }

        [TestMethod]
        public void VerifyDeleteUser()
        {
            var demo = new Demo();
            var user = demo.DeleteUser("api/users/2");
        }
    }
}
