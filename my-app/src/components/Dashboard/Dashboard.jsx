// eslint-disable-next-line no-unused-vars
import { colors, Drawer } from "@mui/material";
import React, { useEffect, useState } from "react";
import { ApiService } from "../../Shared/Services/ServicesService";
import ServiceDetails from "./ServiceDetails";
import { element } from "prop-types";
import { Tabs, Tab } from "@mui/material";

export default function Dashboard({ token }) {
  const apiService = new ApiService(token);

  const [services, SetServices] = useState([]);
  const [serviceActions, SetServiceActions] = useState([]);

  const [index, SetIndex] = useState(null);

  useEffect(() => {
    apiService.Get().then((result) => SetServices(result));
  }, []);

 

  useEffect(() => {
  }, []);

  return (
    <div>
      <h2>Dashboard</h2>
      <Drawer variant="permanent" open={true}>
        {services.map((element, i) => {
          return (
            <button onClick={() => SetIndex(i)} key={element}>
              {element}{" "}
            </button>
          );
        })}
      </Drawer>
        {serviceActions != [] &&
          services.map((element, i) => {
            return (
              <div key={i} hidden={index!=i}>
                <ServiceDetails
                  appService={apiService}
                  service={element}
                ></ServiceDetails>
              </div>
            );
          })}
    </div>
  );
}
