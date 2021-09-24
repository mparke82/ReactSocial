import React from 'react';
import { Button, Container, Menu } from 'semantic-ui-react';

interface Props {
    openForm: () => void;
}

export default function NavBar({openForm}: Props) {
    return (
        <Menu fixed='top'>
            <Menu.Item header>
                <img src="/assets/logo.png" alt="logo" style={{marginRight: '10px'}}/>
                Reactivities
            </Menu.Item>

            <Menu.Menu position='right'>
                <Menu.Item name='Activities'/>
                <Menu.Item>
                    <Button onClick={openForm} compact content='New Activity'/>
                </Menu.Item>
            </Menu.Menu>
        </Menu>
    )
}