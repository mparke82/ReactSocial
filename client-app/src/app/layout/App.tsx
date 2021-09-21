import React, { Fragment, useEffect, useState } from 'react';
import axios from 'axios';
import { Container, Header, Icon, List } from 'semantic-ui-react';
import { Activity } from '../models/Activity';
import NavBar from './NavBar';

function App() {
  // Use state hook from React
  const[activities, setActivities] = useState<Activity[]>([]);// [nameOfVariabletoStoreState, functionToSetState]

  // Fetch our activities from the API server; use hook Use Effect
  useEffect(() => { // Provide this with a function
    axios.get<Activity[]>('http://localhost:5000/api/activities').then(response =>{
      setActivities(response.data);
    })
  }, []) // including this empty array (symbolizing dependencies) ensures this only runs once, and not an endless loop


  return (
    <Fragment>
      <NavBar />
      <Container style={{marginTop: '7em'}}>
        <List>
            {activities.map(activity => (
              <List.Item key={activity.id}>
                {activity.title}
              </List.Item>
            ))} 
        </List>
      </Container>
    </Fragment>
  );
}

export default App;
