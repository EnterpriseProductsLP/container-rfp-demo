﻿// ---------------------------------------------------------------------------------------------------------------
// <copyright file="EventMessageBase.cs" company="Enterprise Products Partners L.P. (Enterprise)">
// © Copyright 2019, Enterprise Products Partners L.P. (Enterprise), All Rights Reserved.
// Permission to use, copy, modify, or distribute this software source code, binaries or
// related documentation, is strictly prohibited, without written consent from Enterprise.
// For inquiries about the software, contact Enterprise: Enterprise Products Company Law
// Department, 1100 Louisiana, 10th Floor, Houston, Texas 77002, phone 713-381-6500.
// </copyright>
// ---------------------------------------------------------------------------------------------------------------

using System.Data.SqlClient;

using Common.Configuration;

namespace Common.Data
{
    public class EventMessageBase
    {
        private readonly IProvideConfiguration _configurationProvider;

        public EventMessageBase(IProvideConfiguration configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_configurationProvider.Configuration["sqlserverConnectionString"]);
        }
    }
}