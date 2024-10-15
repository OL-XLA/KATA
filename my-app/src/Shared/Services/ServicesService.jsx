export class ApiService {
  constructor(token) {
    this.token = token;
  }



  async Get() {
    return fetch("https://localhost:7222/services", {
      method: "GET",
      headers: {
        Authorization: "Bearer " + this.token.token,
      },
    }).then((data) => data.json());
  }

  async  GetService(ServiceName) {
    return fetch("https://localhost:7222/services/$" + ServiceName, {
      method: "GET",
      headers: {
        Authorization: "Bearer " + this.token.token,
      },
    }).then((data) => data.json());
  } 

  async  PostService(ServiceName,ActionName) {
    return fetch("https://localhost:7222/services/$"+ ServiceName, {
      method: "POST",
      headers: {
        Accept: 'application/json, text/plain',
        Authorization: "Bearer " + this.token.token,
        'Content-Type' : 'application/json'
        
      },
      body: JSON.stringify(ActionName)

    }).then((data) => data.json());
  } 
}
