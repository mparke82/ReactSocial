import React, { Fragment, useEffect, useState } from 'react';
import axios from 'axios';
import { Container, Header, Icon, List } from 'semantic-ui-react';
import { Activity } from '../models/Activity';
import NavBar from './NavBar';
import ActivityDashboard from '../../Features/activities/dashboard/ActivityDashboard';

function App() {
  // Use state hook from React
  const[activities, setActivities] = useState<Activity[]>([]);// [nameOfVariabletoStoreState, functionToSetState]
  const [selectedActivity, setSelectedActivity] = useState<Activity | undefined>(undefined);

  // Fetch our activities from the API server; use hook Use Effect
  useEffect(() => { // Provide this with a function
    axios.get<Activity[]>('http://localhost:5000/api/activities').then(response =>{
      setActivities(response.data);
    })
  }, []) // including this empty array (symbolizing dependencies) ensures this only runs once, and not an endless loop

  function handleSelectActivity(id: string) {
    setSelectedActivity(activities.find(x => x.id === id)) // x holds the activity or activities that make up the array
    // find method runs until it finds a matching acitivity to the id, and then we set it equal to the id
  }

  function handleCancelSelectActivity() {
    setSelectedActivity(undefined);
  }

  // we get our activities from the state in the appcomponent
  return (
    <Fragment>
      <NavBar />
      <Container style={{marginTop: '7em'}}>
        <ActivityDashboard activities={activities}
        selectedActivity={selectedActivity}
        selectActivity={handleSelectActivity}
        cancelSelectActivity={handleCancelSelectActivity}
        /> 
      </Container>
    </Fragment>
  );
}

export default App;
