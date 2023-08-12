const baseUrl = "http://localhost:5600"

document.addEventListener("DOMContentLoaded", function () {
    const usernameInput = document.getElementById("username");
    const passwordInput = document.getElementById("password");
    const loginButton = document.querySelector(".btn-login");
    
    console.log(loginButton)

    loginButton.addEventListener("click", function (event) {
      event.preventDefault();

      const username = usernameInput.value;
      const password = passwordInput.value;

      const loginData = {
        userName: username,
        password: password,
      };
  

      console.log(loginData)
      const apiUrl = baseUrl+"/Login";
  
      fetch(apiUrl, {
        method: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        body: JSON.stringify(loginData),
      })
        .then((response) => response.json())
        .then((data) => {
          token = data.token
          if (token) {
            localStorage.setItem('token', token);
            window.location.replace('voting/voting.html')
          } else if (message = data.message) {
            alert(message)
          }
          
        })
        .catch((error) => {
            alert(error)
        });
    });
  });