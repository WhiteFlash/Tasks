import React, { Component } from 'react';   
import { Table, Header, Button } from 'semantic-ui-react'

class TableTask extends Component {
    
    state = { 
        tableHeadings: {
            tableName: "Задачи",
            columHeaders:{
                name: "Наименование",
                description: "Описание",
                status: "Статус"
            }
        }
    }

    componentDidUpdate = (prevProps, prevState, currentProp) =>{
        // console.log("TableTask component prevState = " + prevState);
        // console.log(prevState);
        // console.log("TableTask component prevProps = " + prevProps);
        // console.log(prevProps);
        // console.log("TableTask component this.props");
        // console.log(this.props);

        // console.log(prevProps);
        // console.log("componentDidUpdate method called. dataIsUpdated = " + this.props);

        // if(prevProps.dataIsUpdated === true) {
        //     if( prevProps.data.tasks[this.props.data.tasks.length - 1].tasksID !== prevProps.data.tasks[this.props.data.tasks.length - 1].tasksID) {
        //         {
        //             fetch(URLGETLOCALHOST)
        //             .then(t => t.json())
        //             .then((result) => this.setState({ data: {tasks: result, isLoaded: true}, dataIsUpdated: false }));
                    
        //         }
        //     }
        // } 
    }
    
    render() { 
        if(this.props.data.isLoaded)
        {
            return ( 
                <React.Fragment>
                    <Header as='h3' dividing>
                        {this.state.tableHeadings.tableName}
                    </Header>
                    <Button color='blue' onClick={this.props.onFormAdd}>Добавить</Button>
                    <Table celled selectable>
                        <Table.Header>
                            <Table.Row>
                                <Table.HeaderCell>{this.state.tableHeadings.columHeaders.name}</Table.HeaderCell>
                                <Table.HeaderCell>{this.state.tableHeadings.columHeaders.description}</Table.HeaderCell>
                                <Table.HeaderCell>{this.state.tableHeadings.columHeaders.status}</Table.HeaderCell>
                                <Table.HeaderCell></Table.HeaderCell>
                                <Table.HeaderCell></Table.HeaderCell>
                            </Table.Row>
                        </Table.Header>

                        <Table.Body>     
                            { this.props.data.tasks.map((task) => 
                                <Table.Row key={task.tasksID} >
                                    <Table.Cell>{task.tasksName}</Table.Cell>
                                    <Table.Cell>{task.description}</Table.Cell>
                                    <Table.Cell>{task.status.statusTypes}</Table.Cell>
                                    <Table.Cell> <Button color='purple' onClick={() => this.props.onFormEdit(task.tasksID)}>Редактировать</Button> </Table.Cell>  
                                    <Table.Cell> <Button color='red' onClick={() => this.props.onFormDelete(task.tasksID)}>Удалить</Button> </Table.Cell>
                                </Table.Row>    
                                
                            )}
                        </Table.Body>
                    </Table>
                </React.Fragment>
            );
        }
        else {
            return (
                <React.Fragment>
                <Header as='h3' dividing>
                    {this.state.tableHeadings.tableName}
                </Header>
                <Button color='blue'>Добавить</Button>
                <Table celled selectable>
                    <Table.Header>
                        <Table.Row>
                            <Table.HeaderCell>{this.state.tableHeadings.columHeaders.name}</Table.HeaderCell>
                            <Table.HeaderCell>{this.state.tableHeadings.columHeaders.description}</Table.HeaderCell>
                            <Table.HeaderCell>{this.state.tableHeadings.columHeaders.status}</Table.HeaderCell>
                            <Table.HeaderCell></Table.HeaderCell>
                            <Table.HeaderCell></Table.HeaderCell>
                        </Table.Row>
                    </Table.Header>
                    <Table.Body>
                        <Table.Row >    
                            <Table.Cell>Loading...</Table.Cell>
                        </Table.Row>
                    </Table.Body>   
                </Table>
            </React.Fragment>
            )
        }
    }
}

export default TableTask;