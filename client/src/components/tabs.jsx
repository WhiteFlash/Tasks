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
        fetch(URLGETLOCALHOST)
            .then(t => t.json())
            .then((result) => this.setState({ data: {tasks: result, isLoaded: true} }));
    }
    
   

    saveDataToDataBase = (task) => {

        //TODO: Сделать динамическое обновление таблицы, после добавления элемента из формы в базу.
       
        // task.status.statusID = 1
        // task.status.statusTypes = "Создана";
        console.log("Метод saveDataToDataBase");
        // console.log(task);
        // console.log(this.state.data.tasks[0]);

        let newArrayOfTasks = [...this.state.data.tasks, task];

        
        console.log(task);
        
        let updatedTask = {
            tasksName: task.tasksName, 
            description: task.description,
            status: {
                statusId: 1,
                statusTypes: "Создана"
            }
            
        }
        console.log(updatedTask);
        
        const newArrayOfTasksTwo = Object.assign([], this.state.data.tasks, this.state.data.tasks.push(updatedTask));


        this.setState(prevState => { 
            const dataOne =  { ...prevState.data,
                                    tasks : newArrayOfTasksTwo
                        };                         
        })
    }

    componentDidUpdate = (prevProps, prevState, currentProp) => {
        // console.log("prevState = " + prevState);
        // console.log(prevState);
        // console.log("prevState = " + this.state);
        // console.log(this.state);
        // console.log("prevProps = " + prevProps);
        // console.log(prevProps);
        // console.log("this.props");
        // console.log(this.props);

        // // console.log(prevProps);
        // console.log("componentDidUpdate method called. dataIsUpdated = " + this.props);


        // if(prevState.dataIsUpdated === true) {
        //     if( prevState.data.tasks[this.state.data.tasks.length - 1].tasksID !== prevState.data.tasks[this.state.data.tasks.length - 1].tasksID) {
        //         {
        //             fetch(URLGETLOCALHOST)
        //             .then(t => t.json())
        //             .then((result) => this.setState({ data: {tasks: result, isLoaded: true}, dataIsUpdated: false }));
                    
        //         }
        //     }
        // }            
    }

    render() {    
        
        const showForm = (task) => {            
            if(this.state.isFormShown) {
                return  <Grid.Column>
                            <FadeIn>
                                <FormTab editElement={this.state.updatedElement}
                                         saveElement={this.saveDataToDataBase}
                                         closeFrom={this.closeFrom}
                                         onFormEdit={this.handleFormEdit} />
                            </FadeIn>
                        </Grid.Column>
            }
            else {
                return 
            }
        }

        return (  
            <React.Fragment >
                    <br/>  
                    <Grid container>        
                        <Grid.Row>               
                            <Grid.Column>
                                <TableTask 
                                    onFormEdit={this.handleFormEdit} 
                                    onFormAdd={this.handleFormAdd}
                                    onFormDelete={this.handelDelete}
                                    data ={this.state.data} />
                            </Grid.Column>                   
                        </Grid.Row>
                        <Modal 
                            Inverted
                            onClose={this.closeFrom}
                            onOpen={this.handleFormAdd}
                            open={this.state.isFormShown}
                            size='large'
                            >
                            <Grid.Row>               
                                {showForm()}
                            </Grid.Row> 
                        </Modal>
                    </Grid>
                </React.Fragment> 
            );
        }
    }
    
    export default Tabs;