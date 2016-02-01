using System.Threading.Tasks;
using edjCase.JsonRpc.Client;
using edjCase.JsonRpc.Core;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Generic;
using RPCRequestResponseHandlers;

namespace Nethereum.RPC.Eth
{

    ///<Summary>
    /// eth_getTransactionCount
    /// 
    /// Returns the number of transactions sent from an address.
    /// 
    /// Parameters
    /// 
    /// DATA, 20 Bytes - address.
    /// QUANTITY|TAG - integer block number, or the string "latest", "earliest" or "pending", see the default block parameter
    /// params: [
    ///    '0x407d73d8a49eeb85d32cf465507dd71d507100c1',
    ///    'latest' // state at the latest block
    /// ]
    /// Returns
    /// 
    /// QUANTITY - integer of the number of transactions send from this address.
    /// 
    /// Example
    /// 
    ///  Request
    /// curl -X POST --data '{"jsonrpc":"2.0","method":"eth_getTransactionCount","params":["0x407d73d8a49eeb85d32cf465507dd71d507100c1","latest"],"id":1}'
    /// 
    ///  Result
    /// {
    ///   "id":1,
    ///   "jsonrpc": "2.0",
    ///   "result": "0x1" // 1
    /// }
    ///     
    ///</Summary>
    public class EthGetTransactionCount : RpcRequestResponseHandler<HexBigInteger>
    {
        public EthGetTransactionCount(RpcClient client) : base(client, ApiMethods.eth_getTransactionCount.ToString())
        {
        }

        public async Task<HexBigInteger> SendRequestAsync( string address, BlockParameter block,
            string id = Constants.DEFAULT_REQUEST_ID)
        {
            return await base.SendRequestAsync( id, address, block);
        }

        public async Task<HexBigInteger> SendRequestAsync( string address,
            string id = Constants.DEFAULT_REQUEST_ID)
        {
            return await SendRequestAsync( address, BlockParameter.CreateLatest(), id);
        }

        public RpcRequest BuildRequest(string address, BlockParameter block, string id = Constants.DEFAULT_REQUEST_ID)
        {
            return base.BuildRequest(id, address, block);
        }
    }
}