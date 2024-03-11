using CafePOS.Core.DTOs;
using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;
using CafePOS.Core.Interfaces.Services;

namespace CafePOS.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public Result<bool> OrderHasItems(int orderId)
        {
            try
            {
                var hasItems = _paymentRepository.OrderHasItems(orderId);
                if (!hasItems)
                {
                    return ResultFactory.Fail<bool>("This order has no items currently. Try cancelling the order instead.");
                }
                else
                {
                    return ResultFactory.Success(true);
                }
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<bool>(ex.Message);
            }
        }

        public Result<List<PaymentType>> GetPaymentTypes()
        {
            try
            {
                var types = _paymentRepository.GetPaymentTypes();
                if (types.Count == 0)
                {
                    return ResultFactory.Fail<List<PaymentType>>("Error getting payment types.");
                }
                return ResultFactory.Success(types);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<List<PaymentType>>(ex.Message);
            }
        }

        public Result ProcessPayment(int orderId, int paymentType)
        {
            try
            {
                bool validPaymentType = _paymentRepository.IsValidPaymentType(paymentType);

                if (!validPaymentType)
                {
                    return ResultFactory.Fail("That is not a valid payment type.");
                }

                _paymentRepository.ProcessPayment(orderId, paymentType);
                return ResultFactory.Success();
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail(ex.Message);
            }
        }

        public Result<CafeOrder> GetOrderSubtotals(int orderId)
        {
            try
            {
                var orderTotals = _paymentRepository.GetOrderSubtotals(orderId);

                return ResultFactory.Success(orderTotals);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<CafeOrder>(ex.Message);
            }
        }

        public Result AddTipToOrder(int orderId, decimal tip)
        {
            try
            {
                var isUnder15items = _paymentRepository.IsOrderUnder15Items(orderId);
                var totals = _paymentRepository.GetOrderSubtotals(orderId);
                bool isCustomerTipOver15Percent = (totals.SubTotal * .15M) < tip;

                if (!isUnder15items && !isCustomerTipOver15Percent && totals.SubTotal != null)
                {
                    decimal newTip = (decimal)totals.SubTotal * .15M;
                    _paymentRepository.AddTipToOrder(orderId, newTip);
                    return ResultFactory.Success("Tip amount entered did not meet minimum. Tip was adjusted to 15%.");
                }
                if (!isUnder15items && isCustomerTipOver15Percent)
                {
                    _paymentRepository.AddTipToOrder(orderId, tip);
                    return ResultFactory.Success("Tip amount has been applied to order.");
                }
                else
                {
                    _paymentRepository.AddTipToOrder(orderId, tip);
                    return ResultFactory.Success("Tip amount has been applied to order.");
                }
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail(ex.Message);
            }
        }

        public Result<decimal> GetFinalTotal(int orderId)
        {
            try
            {
                var total = _paymentRepository.GetFinalTotal(orderId);
                return ResultFactory.Success(total);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<decimal>(ex.Message);
            }
        }

        public Result<bool> OrderIsUnder15items(int orderId)
        {
            try
            {
                var IsUnder15Items = _paymentRepository.IsOrderUnder15Items(orderId);
                if (!IsUnder15Items)
                {
                    return ResultFactory.Fail<bool>("NOTE: Order has over 15 items. Minimum of a 15% tip is required. System will increase tip if less than 15% is entered.");
                }
                return ResultFactory.Success(true);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<bool>(ex.Message);
            }
        }
    }
}
