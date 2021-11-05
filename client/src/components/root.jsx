import React, { Component } from 'react';

import Grid from '@mui/material/Grid';
import Button from '@mui/material/Button';
import Brightness6OutlinedIcon from '@mui/icons-material/Brightness6Outlined';
import LanguageOutlinedIcon from '@mui/icons-material/LanguageOutlined';



import TasksTable from './tasksTable.jsx';
import { GET_NOTE, GET_NOTES_All } from '../const/ApiNoteConsts.js'
import { Box } from '@mui/system';


class Root extends Component {
    state = {     
        isFormShown: false,
        data: {
            tasks: [],
            isLoaded: false
        },
        updatedElement: null,
        dataIsUpdated: false
    }
    
    handleFormEdit = (id) => {         
        const element = this.state.data.tasks.find(t => t.tasksID === id);
        if(this.state.isFormShown) {
            this.setState(
                {
                    updatedElement: element
                });
        }
        else {
            this.setState(
                {
                    updatedElement: element
                });
            this.closeFrom();
            }
        }

    handleFormAdd = () => {
        if(this.state.isFormShown){
            this.setState(
                {
                    updatedElement: {
                        tasksName: " ",
                        description: " ",
                    }
                });
        }
        else {
            this.setState(
                {
                    updatedElement: {}
                });
                this.closeFrom();
        }
    }

    closeFrom = () => {
        this.setState({ isFormShown : !this.state.isFormShown} );
    }

    handelDelete = (id) => {
        
    }
    
    componentDidMount = () =>
    {
    }
    
   

    saveDataToDataBase = (task) => {

    }

    componentDidUpdate = (prevProps, prevState, currentProp) => {
     
    }

    changeLang = () => {
        alert();
    }


    changeTheme = () => {
        alert();
    }

    render() {   
        return (  
                <React.Fragment>

                       <Grid container spacing={3}>
                            <Grid item>
                                <Box sx={{marginTop: "6px"}}>
                                    <Brightness6OutlinedIcon onClick={this.changeLang}/>
                                </Box>
                            </Grid>
                            <Grid item>
                                <Box sx={{marginTop: "5px"}}>
                                    <LanguageOutlinedIcon onClick={this.changeTheme}></LanguageOutlinedIcon>
                                </Box>
                            </Grid>
                            <Grid item>
                                <Button variant="primary">Login</Button>
                            </Grid>
                            <Grid item xs={12}>
                                <TasksTable></TasksTable>
                            </Grid>
                        </Grid>
                </React.Fragment> 
            );
        }
    }
    
    export default Root;