using CafePOS.Application.Services;
using CafePOS.Tests.MockRepos.ReportRepo;
using NUnit.Framework;

namespace CafePOS.Tests
{
    [TestFixture]
    public class ReportServiceTests
    {
        [Test]
        public void GetSalesReportCategoriesByDay_Fails_WhenNoReportsAvailable()
        {
            var service = new ReportService(new NoReportsAvailable());

            var result = service.GetSalesReportCategoriesByDay(DateTime.Today);

            Assert.That(result.Ok, Is.False);
        }

        [Test]
        public void GetSalesReportCategoriesByDay_ReturnsReport_WhenReportsAvailable()
        {
            var service = new ReportService(new ReportsAvailable());

            var result = service.GetSalesReportCategoriesByDay(DateTime.Today);

            Assert.That(result.Ok, Is.True);
            Assert.That(result.Data.Count, Is.EqualTo(4));
        }

        [Test]
        public void GetSalesReportItemsByDay_Fails_WhenNoReportsAvailable()
        {
            var service = new ReportService(new NoReportsAvailable());

            var result = service.GetSalesReportItemsByDay(DateTime.Today);

            Assert.That(result.Ok, Is.False);
        }

        [Test]
        public void GetSalesReportItemsByDay_ReturnsReport_WhenReportsAvailable()
        {
            var service = new ReportService(new ReportsAvailable());

            var result = service.GetSalesReportItemsByDay(DateTime.Today);

            Assert.That(result.Ok, Is.True);
            Assert.That(result.Data.Count, Is.EqualTo(6));
        }
    }
}
