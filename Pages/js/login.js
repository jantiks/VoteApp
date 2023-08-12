import { baseUrl } from './Constants'

document.addEventListener("DOMContentLoaded", function () {
    // Get references to the input fields and login button
    const usernameInput = document.getElementById("username");
    const passwordInput = document.getElementById("password");
    const loginButton = document.querySelector(".btn-login");
    
    console.log(loginButton)
    // Add a click event listener to the login button
    loginButton.addEventListener("click", function (event) {
      event.preventDefault(); // Prevent the form from submitting
  
      // Get the entered username and password
      const username = usernameInput.value;
      const password = passwordInput.value;
      // Create an object with the login data
      const loginData = {
        userName: username,
        password: password,
      };
  

      console.log(loginData)
      // Replace 'YOUR_LOGIN_API_URL' with the actual URL of your login endpoint
      const apiUrl = baseUrl+"/Login";
  
      // Make a POST request to the login endpoint using the fetch API
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
          localStorage.setItem('token', data.token);
          window.location.replace('voting/voting.html')
        })
        .catch((error) => {
            alert(error)
        });
    });
  });