
export class AuthService{

    constructor(){
    }

    async  loginUser(credentials) {
        return fetch('http://localhost:7221/auth', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(credentials)
        })
          .then(data => data.json())
       }
}