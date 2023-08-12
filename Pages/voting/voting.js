const baseUrl = "http://localhost:5600"

function fetchCandidates() {
    fetch(baseUrl+'/Votes')
      .then(response => response.json())
      .then(data => {
        // Loop through each candidate and update the DOM
        data.forEach(candidate => {
          const candidateDiv = document.createElement('div');
          candidateDiv.className = 'candidate';
  
          const candidateDetailsDiv = document.createElement('div');
          candidateDetailsDiv.className = 'candidate-details';
  
          const candidateNameDiv = document.createElement('div');
          candidateNameDiv.className = 'candidate-name';
          candidateNameDiv.textContent = candidate.title;
  
          const voteCountDiv = document.createElement('div');
          voteCountDiv.className = 'vote-count';
          voteCountDiv.innerHTML = `Votes: <span id="votes${candidate.id}">${candidate.votes}</span>`;
  
          candidateDetailsDiv.appendChild(candidateNameDiv);
          candidateDetailsDiv.appendChild(voteCountDiv);
  
          const voteButton = document.createElement('button');
          voteButton.className = 'vote-button';
          voteButton.textContent = 'Vote';
          voteButton.onclick = () => vote(candidate.id);
  
          candidateDiv.appendChild(candidateDetailsDiv);
          candidateDiv.appendChild(voteButton);
  
          document.querySelector('.container').appendChild(candidateDiv);
        });
      })
      .catch(error => {
        console.error('Error fetching candidates:', error);
      });
  }
  
  function vote(candidateId) {
    const body = {

    }
    fetch(baseUrl+`/incrementChoice?id=${candidateId}`, { method: 'POST' })
      .then(response => response.json())
      .then(data => {
        document.getElementById(`votes${candidateId}`).textContent = data.newVoteCount;
      })
      .catch(error => {
        console.error('Error voting:', error);
      });
  }

  function addLogoutEventListener() {
    const logoutButton = document.querySelector(".logout");
    console.log(logoutButton)

    logoutButton.onclick = () => {
        localStorage.removeItem("token");
        window.location.replace('../index.html')
    }
  }

  document.addEventListener("DOMContentLoaded", function () {  
    console.log("Hello world")
    fetchCandidates();
    addLogoutEventListener();
  })