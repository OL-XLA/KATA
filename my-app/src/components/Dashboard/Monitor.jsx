import PropTypes from "prop-types";
import { useEffect, useState } from "react";
import { Box } from "@mui/material";
import Connector from "../../signalr-connection.ts"

export default function Monitor({ StreamId,name }) {
  const [message, setMessage] = useState("RIENG");

  let { GetConnected, Register, events } = Connector(StreamId);

  useEffect(() => {
    const handleMessageReceived = (_, message) => setMessage(JSON.stringify(message));
    const OnLogUpdated = (log, guid) => {
      if (guid == StreamId) setMessage(log);
    };
    events(handleMessageReceived, OnLogUpdated);


    async function WaitForConnection(){
      while(true){
        if (GetConnected()) 
          {
          Register(StreamId);
          return;
        }
        else
        {
          await new Promise(resolve => setTimeout(resolve, 200));
        }
      }
    
    }

    WaitForConnection().catch(console.error);
  },[]);

  useEffect(() => {
    
  }, [GetConnected]);

  return (
    <div className="App">
      Response of {name}  : {StreamId}
      <Box style={{whiteSpace:"pre-wrap"}}>{message}</Box>

      
    </div>
  );
}

Monitor.propTypes = {
  StreamId: PropTypes.any.isRequired,
  // appService: ApiService.isRequired,
};
