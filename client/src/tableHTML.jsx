import React, { Component } from 'react';
import { Button, Header } from 'semantic-ui-react';

class TableHTML extends Component {
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
    render() { 
        if(this.props.data.isLoaded){
            return ( 

                <React.Fragment>
                     <Header as='h3' dividing>
                        {this.state.tableHeadings.tableName}
                    </Header>
                    <table className="ui celled table">
                        <thead>
                            <tr>
                                <th>{this.state.tableHeadings.columHeaders.name}</th>
                                <th>{this.state.tableHeadings.columHeaders.description}</th>
                                <th>{this.state.tableHeadings.columHeaders.status}</th>
                                <th></th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            {this.props.data.tasks.map((task) => 
                                <tr  key={task.tasksID}>
                                    <td data-label="Number">{task.tasksName}</td>
                                    <td data-label="Title">{task.description}</td>
                                    <td data-label="RegDate">{task.status.statusTypes}</td>
                                    <td> <Button color='purple' onClick={() => this.props.onFormEdit(task)}>Редактировать</Button> </td>
                                    <td><Button color='red'>Удалить</Button></td>
                                </tr>
                            )}
                        </tbody>
                    </table>
                </React.Fragment>
         );
        }
        else {
            return <div>Загрузка</div>
        }
    }
}
 
export default TableHTML;