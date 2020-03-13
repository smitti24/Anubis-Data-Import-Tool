using PostgreSQLCopyHelper;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Anubis.Architecture
{
    public static class PostgreSqlHelper
    {
        public static PostgreSQLCopyHelper<TEntity> CreateHelper<TEntity>(string schemaName, string tableName)
        {
            PostgreSQLCopyHelper<TEntity> helper = new PostgreSQLCopyHelper<TEntity>("dbo", "\"" + tableName + "\"");
            PropertyInfo[] properties = typeof(TEntity).GetProperties();

            foreach (PropertyInfo propertyInfo in properties)
            {
                Type type = propertyInfo.PropertyType;

                if (Attribute.IsDefined(propertyInfo, typeof(KeyAttribute)) || Attribute.IsDefined(propertyInfo, typeof(ForeignKeyAttribute)))
                    continue;

                switch (type)
                {
                    case Type intType when intType == typeof(int) || intType == typeof(int?):
                        {
                            helper = helper.MapInteger("\"" + propertyInfo.Name + "\"", x => (int?)typeof(TEntity).GetProperty(propertyInfo.Name)?.GetValue(x, null));
                            break;
                        }
                    case Type stringType when stringType == typeof(string):
                        {
                            helper = helper.MapText("\"" + propertyInfo.Name + "\"", x => (string)typeof(TEntity).GetProperty(propertyInfo.Name)?.GetValue(x, null));
                            break;
                        }
                    case Type dateType when dateType == typeof(DateTime) || dateType == typeof(DateTime?):
                        {
                            helper = helper.MapTimeStamp("\"" + propertyInfo.Name + "\"", x => (DateTime?)typeof(TEntity).GetProperty(propertyInfo.Name)?.GetValue(x, null));
                            break;
                        }
                    case Type decimalType when decimalType == typeof(decimal) || decimalType == typeof(decimal?):
                        {
                            helper = helper.MapMoney("\"" + propertyInfo.Name + "\"", x => (decimal?)typeof(TEntity).GetProperty(propertyInfo.Name)?.GetValue(x, null));
                            break;
                        }
                    case Type doubleType when doubleType == typeof(double) || doubleType == typeof(double?):
                        {
                            helper = helper.MapDouble("\"" + propertyInfo.Name + "\"", x => (double?)typeof(TEntity).GetProperty(propertyInfo.Name)?.GetValue(x, null));
                            break;
                        }
                    case Type floatType when floatType == typeof(float) || floatType == typeof(float?):
                        {
                            helper = helper.MapReal("\"" + propertyInfo.Name + "\"", x => (float?)typeof(TEntity).GetProperty(propertyInfo.Name)?.GetValue(x, null));
                            break;
                        }
                    case Type guidType when guidType == typeof(Guid):
                        {
                            helper = helper.MapUUID("\"" + propertyInfo.Name + "\"", x =>
                            {
                                if (propertyInfo != null)
                                    return (Guid)typeof(TEntity).GetProperty(propertyInfo.Name)?.GetValue(x, null);

                                return Guid.Empty;
                            });
                            break;
                        }
                }
            }

            return helper;
        }
    }
}
