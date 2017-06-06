using iPartnerApp.Enums;
using iPartnerApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace iPartnerApp.DataBaseService
{
    public static class SqlLiteDataBaseService
    {
        private static SQLiteConnection _connection;
        static SqlLiteDataBaseService()
        {
            _connection = DependencyService.Get<ISqlLite>().GetDataBase();
            _connection.CreateTable<LocalOrderStatus>();
        }
        /// <summary>
        /// Save or update order status in local DB
        /// </summary>
        /// <param name="orderId">Order ID</param>
        /// <param name="orderStatus">Current order status</param>
        /// <returns></returns>
        public static bool SaveOrderStatus(int orderId, OrderStatus orderStatus)
        {
            return _connection.InsertOrReplace(new LocalOrderStatus { OrderId = orderId, Status = orderStatus }) != -1;
        }
        /// <summary>
        /// Get status by order id
        /// </summary>
        /// <param name="orderId">Order id</param>
        /// <returns></returns>
        public static OrderStatus? GetLocalOrderStatus(int orderId)
        {
            var record = _connection.Table<LocalOrderStatus>().FirstOrDefault(x => x.OrderId == orderId);
            return record == null ? null : (OrderStatus?)record.Status;
        }
    }
}
