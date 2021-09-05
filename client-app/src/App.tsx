import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { Header, Icon, List } from 'semantic-ui-react';

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
    <div>
      <Header as='h1' icon textAlign='center'>
        <Icon name='address book outline' circular />
        <Header.Content>Reactivities</Header.Content>
      </Header>
      <List>
          {activities.map((activity: any) => (
            <List.Item key={activity.id}>
              {activity.title}
            </List.Item>
          ))} 
      </List>
    </div>
  );
}

export default App;
