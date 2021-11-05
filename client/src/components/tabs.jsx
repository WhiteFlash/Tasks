import React, { Component } from 'react';
import { Form, Tab, Grid, Modal } from 'semantic-ui-react';
import FadeIn from 'react-fade-in';

import FormTab from './formTab';
import TableTask  from './table';
import { URLGETLOCALHOST, URL_LOCALHOST_DELETE } from '../const/const.js'



class Tabs extends Component {
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
        console.log(id);
        fetch(URL_LOCALHOST_DELETE, {
            method: "DELETE",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(id)
        });
    }
    
    componentDidMount = () =>
    {
    }
    
   

    saveDataToDataBase = (task) => {

    }

    componentDidUpdate = (prevProps, prevState, currentProp) => {
     
    }

    render() {    
        
       

        return (  
            <React.Fragment >
                    <br/>  
                    <Grid container>        
                        <Grid.Row>               
                            <Grid.Column>
                                <TableTask />
                            </Grid.Column>                   
                        </Grid.Row>
                      </Grid>
                </React.Fragment> 
            );
        }
    }
    
    export default Tabs;