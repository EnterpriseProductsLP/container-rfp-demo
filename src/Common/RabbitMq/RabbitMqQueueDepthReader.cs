﻿// ---------------------------------------------------------------------------------------------------------------
// <copyright file="RabbitMqQueueDepthReader.cs" company="Enterprise Products Partners L.P. (Enterprise)">
// Copyright 2019, Enterprise Products Partners L.P. (Enterprise), All Rights Reserved.
// Permission to use, copy, modify, or distribute this software source code, binaries or
// related documentation, is strictly prohibited, without written consent from Enterprise.
// For inquiries about the software, contact Enterprise: Enterprise Products Company Law
// Department, 1100 Louisiana, 10th Floor, Houston, Texas 77002, phone 713-381-6500.
// </copyright>
// ---------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;

using RabbitMQ.Client;

namespace Common.RabbitMq
{
    public class RabbitMqQueueDepthReader : IGetQueueDepths
    {
        public async Task<uint> GetQueueDepth(string queueName)
        {
            var connectionAttempts = 1;

            while (true)
            {
                try
                {
                    var connectionFactory = new ConnectionFactory
                    {
                        UserName = "admin",
                        Password = "yourStrong(!)Password",
                        VirtualHost = "/",
                        HostName = "rabbitmq"
                    };

                    var connection = connectionFactory.CreateConnection();
                    var channel = connection.CreateModel();
                    var response = channel.QueueDeclarePassive(queueName);

                    return response.MessageCount;
                }
                catch (Exception)
                {
                    if (connectionAttempts >= 10)
                    {
                        throw;
                    }

                    var delay = 100 * (int)Math.Pow(2, connectionAttempts++);
                    await Task.Delay(delay).ConfigureAwait(false);
                }
            }
        }
    }
}
