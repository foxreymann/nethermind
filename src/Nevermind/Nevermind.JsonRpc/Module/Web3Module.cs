﻿/*
 * Copyright (c) 2018 Demerzel Solutions Limited
 * This file is part of the Nethermind library.
 *
 * The Nethermind library is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * The Nethermind library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with the Nethermind. If not, see <http://www.gnu.org/licenses/>.
 */

using System.Reflection;
using Nevermind.Blockchain;
using Nevermind.Core;
using Nevermind.Core.Crypto;
using Nevermind.JsonRpc.DataModel;

namespace Nevermind.JsonRpc.Module
{
    public class Web3Module : ModuleBase, IWeb3Module
    {
        public Web3Module(ILogger logger, IConfigurationProvider configurationProvider) : base(logger, configurationProvider)
        {
        }

        public ResultWrapper<string> web3_clientVersion()
        {
            var version = Assembly.GetAssembly(typeof(IBlockchainProcessor)).GetName().Version;
            var clientVersion = $"EthereumNet v{version}";
            Logger.Debug($"web3_clientVersion request, result: {clientVersion}");
            return ResultWrapper<string>.Success(clientVersion);
        }

        public ResultWrapper<Data> web3_sha3(Data data)
        {
            var keccak = Sha3(data);
            Logger.Debug($"web3_sha3 request, result: {keccak.ToJson()}");
            return ResultWrapper<Data>.Success(keccak);
        }
    }
}