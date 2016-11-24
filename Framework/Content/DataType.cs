﻿using System;

namespace OpenData.Framework.Common
{
    /// <summary>
    /// Use in cms.
    /// </summary>
    public enum ColumnType
    {
        String,
        Int,
        Decimal,
        DateTime,
        Bool
    }
    /// <summary>
    /// 
    /// </summary>
    public static class DataTypeHelper
    {
        #region Methods
        /// <summary>
        /// Defaults the value.
        /// </summary>
        /// <param name="dataType">Type of the data.</param>
        /// <returns></returns>
        public static object DefaultValue(ColumnType dataType)
        {
            switch (dataType)
            {
                case ColumnType.String:
                    return "";
                case ColumnType.Int:
                    return default(int);
                case ColumnType.Decimal:
                    return default(decimal);
                case ColumnType.DateTime:
                    return DateTime.UtcNow;
                case ColumnType.Bool:
                    return default(bool);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Parses the value.
        /// </summary>
        /// <param name="dataType">Type of the data.</param>
        /// <param name="value">The value.</param>
        /// <param name="throwWhenInvalid">if set to <c>true</c> [throw when invalid].</param>
        /// <returns></returns>
        /// <exception cref="OpenData.BzwayException"></exception>
        public static object ParseValue(ColumnType dataType, string value, bool throwWhenInvalid)
        {
            switch (dataType)
            {
                case ColumnType.String:
                    return value;
                case ColumnType.Int:
                    int intValue;
                    if (int.TryParse(value, out intValue))
                    {
                        return intValue;
                    }
                    else
                    {
                        if (throwWhenInvalid)
                        {
                            throw new InvalidCastException("The value is invalid.");
                        }
                        return default(int);
                    }
                case ColumnType.Decimal:
                    decimal decValue;
                    if (decimal.TryParse(value, out decValue))
                    {
                        return decValue;
                    }
                    else
                    {
                        if (throwWhenInvalid)
                        {
                            throw new InvalidCastException("The value is invalid.");
                        }
                        return default(decimal);
                    }
                case ColumnType.DateTime:
                    DateTime dateTime;
                    if (DateTime.TryParse(value, out dateTime))
                    {
                        if (dateTime.Kind != DateTimeKind.Utc)
                        {
                            dateTime = new DateTime(dateTime.Ticks, DateTimeKind.Local).ToUniversalTime();
                        }
                        return dateTime;

                    }
                    else
                    {
                        if (throwWhenInvalid)
                        {
                            throw new InvalidCastException("The value is invalid.");
                        }
                        return default(DateTime);
                    }
                case ColumnType.Bool:
                    if (!string.IsNullOrEmpty(value))
                    {
                        bool boolValue;
                        if (bool.TryParse(value, out boolValue))
                        {
                            return boolValue;
                        }
                        else
                        {
                            if (throwWhenInvalid)
                            {
                                throw new InvalidCastException("The value is invalid.");
                            }
                            return default(bool);
                        }
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return null;
            }

        }
        #endregion
    }
}
