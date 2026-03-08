// const xhr = new XMLHttpRequest();

// xhr.open('GET', 'https://api.example.com/data', true);

// xhr.onload = function () {
//   if (xhr.status === 200) { // Check for successful HTTP status code
//     const data = JSON.parse(xhr.responseText);
//     console.log(data);
//   } else {
//     console.error('Error:', xhr.statusText);
//   }
// };

// xhr.onerror = function() {
//   console.error("Network Error"); // Handles network issues
// };

// xhr.send();

const xhr = new XMLHttpRequest();
const url = "https://jsonplaceholder.typicode.com/todos"; // Replace with a valid API endpoint

xhr.open("GET", url, true); // true makes the request asynchronous

xhr.onload = function () {
  // Check if the request was successful (status code 200-299)
  if (xhr.status >= 200 && xhr.status < 300) {
    // Parse the response text as JSON
    const data = JSON.parse(xhr.responseText);
    console.log("Response:", data);
  } else {
    // Handle HTTP errors
    console.error("Error:", xhr.status, xhr.statusText);
  }
};

xhr.onerror = function () {
  // Handle network errors (e.g., connection issues)
  console.error("Network Error");
};

xhr.send(); // Sends the request
