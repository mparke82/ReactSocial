import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';

function App() {
  // Use state hook from React
  const[activities, setActivities] = useState([]);// [nameOfVariabletoStoreState, functionToSetState]

  // Fetch our activities from the API server; use hook Use Effect
  useEffect(() => { // Provide this with a function
    axios.get('http://localhost:5000/api/activities').then(response =>{
      console.log(response);
      setActivities(response.data);
    })
  }, []) // including this empty array (symbolizing dependencies) ensures this only runs once, and not an endless loop


  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <ul>
          {/* JS code inside the curly brackets, map accepts a callback for each element in an array so we can do something with it */}
          {activities.map((activity: any) => (
            <li key={activity.id}>
              {activity.title}
            </li>
          ))} 
        </ul>
      </header>
    </div>
  );
}

export default App;
