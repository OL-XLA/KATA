import PropTypes from "prop-types";
import { useEffect, useState } from "react";
import { ApiService } from "../../Shared/Services/ServicesService";
import Monitor from "./Monitor";
import { Box } from "@mui/material";

export default function ServiceDetails({ appService, service }) {
  const [actions, setActions] = useState([]);

  const [goingActions, setGoingActions] = useState([]);

  useEffect(() => {
    appService.GetService(service).then((result) => {
      console.log(result);
      setActions(result);
    });
  }, [service]);

  function HandleActionClick(element) {
    appService
      .PostService(service, element)
      .then((result) => setGoingActions([...goingActions, { id: result , name:element }]));
  }

  return (
    <div>
      {actions.length != undefined &&
        actions.map((element, i) => {
          return (
            <button onClick={() => HandleActionClick(element)} key={element}>
              {element}
            </button>
          );
        })}
      <div style={{ display: "flex", flexDirection: "row" ,gap:"40px",overflow:"auto",width:"max-content"}}>
        {goingActions != [] &&
          goingActions.map((element) => {
            return (
              <Box  key={element.id}>
                <Monitor StreamId={element.id} name={element.name}> </Monitor>
              </Box>
            );
          })}
      </div>
    </div>
  );
}

ServiceDetails.propTypes = {
  actions: PropTypes.array.isRequired,
  service: PropTypes.any.isRequired,
  appService: ApiService.isRequired,
};
