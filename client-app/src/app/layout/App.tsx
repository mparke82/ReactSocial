import React, { Fragment, useEffect, useState } from 'react';
import axios from 'axios';
import { Container, Header, Icon, List } from 'semantic-ui-react';
import { Activity } from '../models/Activity';
import NavBar from './NavBar';
import ActivityDashboard from '../../Features/activities/dashboard/ActivityDashboard';

function App() {
  // Use state hook from React
  const[activities, setActivities] = useState<Activity[]>([]);// [nameOfVariabletoStoreState, functionToSetState]

  // Fetch our activities from the API server; use hook Use Effect
  useEffect(() => { // Provide this with a function
    axios.get<Activity[]>('http://localhost:5000/api/activities').then(response =>{
      setActivities(response.data);
    })
  }, []) // including this empty array (symbolizing dependencies) ensures this only runs once, and not an endless loop

  // we get our activities from the state in the appcomponent
  return (
    <Fragment>
      <NavBar />
      <Container style={{marginTop: '7em'}}>
        <ActivityDashboard activities={activities}/> 
      </Container>
    </Fragment>
  );
}

export default App;
