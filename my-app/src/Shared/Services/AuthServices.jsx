
export class AuthService{

    constructor(){
    }

    async  loginUser(credentials) {
        return fetch('https://localhost:7222/auth', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(credentials)
        })
          .then(data => data.json())
       }
}