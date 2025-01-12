using CafePOS.Application.Services;
using CafePOS.Core.DTOs;
using CafePOS.Core.Interfaces.Application;
using CafePOS.Core.Interfaces.Services;
using CafePOS.Core.TimeOfDaySettings;
using CafePOS.Data.Repositories;
using CafePOS.Data.TrainingRepositories;

namespace CafePOS.Application
{
    public class ServiceFactory
    {
        private readonly IAppConfiguration _config;
        private readonly ITimeOfDaySetting _timeOfDaySetting;
        private readonly TrainingMode _trainingMode;

        public ServiceFactory(IAppConfiguration config)
        {
            _config = config;
            _timeOfDaySetting = GetTimeOfDay();
            _trainingMode = _config.GetTrainingModeSetting();
        }

        public ITimeOfDaySetting GetTimeOfDay()
        {
            switch (_config.GetTimeOfDayMode())
            {
                case TimeOfDayMode.RealTime:
                    return new RealTime();
                case TimeOfDayMode.Breakfast:
                    return new Breakfast();
                case TimeOfDayMode.Lunch:
                    return new Lunch();
                case TimeOfDayMode.Dinner:
                    return new Dinner();
                default:
                case TimeOfDayMode.HappyHour:
                    return new HappyHour();
            }
        }
        public INewOrderService CreateNewOrderService()
        {
            if (_trainingMode == TrainingMode.Enabled)
            {
                return new NewOrderService(new TrainingServerRepository());
            }
            else
            {
                return new NewOrderService(
                    new ServerRepository(_config.GetConnectionString()));
            }
        }

        public IOrderService CreateOrderService()
        {
            if (_trainingMode == TrainingMode.Enabled)
            {
                return new OrderService(new TrainingOrderRepository(), _timeOfDaySetting);
            }
            else
            {
                return new OrderService(
                new OrderRepository(_config.GetConnectionString()), _timeOfDaySetting);
            }
        }
        
        public IPaymentService CreatePaymentService()
        {
            if (_trainingMode == TrainingMode.Enabled)
            {
                return new PaymentService(new TrainingPaymentRepository());
            }
            else
            {
                return new PaymentService(
                new PaymentRepository(_config.GetConnectionString()));
            }
        }

        public IReportService CreateReportService()
        {
            if (_trainingMode == TrainingMode.Enabled)
            {
                return new ReportService(new TrainingReportRepository());
            }
            else
            {
                return new ReportService(
                new ReportRepository(_config.GetConnectionString()));
            }
        }
    }
}
