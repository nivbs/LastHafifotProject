using System;
using Core;
using MySql.Data.MySqlClient;

namespace DAL
{
    public static class MySqlDataReaderExtensions
    {
            public static ExpandPurchase GetExpandPurchaseFromRow(this MySqlDataReader mySqlDataReader)
                => new ExpandPurchase(mySqlDataReader["id"].ToString(), mySqlDataReader["store_type"].ToString(), mySqlDataReader["store_id"].ToString(),
                        mySqlDataReader["activity_days"].ToString(), mySqlDataReader["credit_card"].ToString(), DateTime.Parse(mySqlDataReader["purchase_date"].ToString()),
                        DateTime.Parse(mySqlDataReader["insertion_date"].ToString()), float.Parse(mySqlDataReader["total_price"].ToString()), int.Parse(mySqlDataReader["installments"].ToString()),
                        float.Parse(mySqlDataReader["price_per_installment"].ToString()), (mySqlDataReader["is_valid"].ToString() == "1"), mySqlDataReader["why invalid"].ToString());
    }
}
