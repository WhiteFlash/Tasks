import React, { Component } from 'react';
import { 
    Button,
    Checkbox,
    Form,
    Input,
    Radio,
    Select,
    TextArea,
    Grid 
} from 'semantic-ui-react'

import {GET_URL_LOCALHOST_STATUSES, URLGETLOCALHOST } from '../const/const.js';



class FormTab extends Component {
    state = { 
        formInputFieldsConfig: {
            nameField:{
                lable: "Наименование",
                placeholder: "Наименование"
            },
            descriptionField:{
                lable: "Описание",
                placeholder: "Описание"
            },
            selectedField: {
                lable: "Статус",
                placeholder: "Статус"
            }
       
       
        
        },
        
        statuses : [
                    { key:1, text: "Создана", value: this.key },
                    { key:2, text: "В работе", value: this.key }, 
                    { key:3, text: "Завершена", value: this.key},
                ],

        task: this.props.editElement,
        nameField: "",
        descriptionField: "",
        statusField: ""
        
    }

    componentDidMount = () => {
        fetch(GET_URL_LOCALHOST_STATUSES)
            .then(res => res.json())
            .then((s) => {
                this.setState({statuses: this.formatObject(s)});
            });
            // .then(s => this.setState({statuses: this.statuseslocal}));
    }

    formatObject = (formatedArray) => {
        let newArray = [];
        let status = {key: null, text: null, value: this.text};

        // console.log("formated array");
        // console.log(formatedArray);

        for(let i = 0; i < formatedArray.length; i++)
        {
            status.key = formatedArray[i].statusID;
            status.text = formatedArray[i].statusTypes;
            status.value = formatedArray[i].statusID; 
            // console.log(status);
            // console.log(formatedArray[i]);
            newArray.push(status);
        }

        return newArray;
    }


    handleChangeTasksName = (e) => {   
        this.setState({nameField: e.target.value});
    }

    handleChangeTasksDescriptionField = (e) => {
        this.setState({descriptionField: e.target.value});
    }

    handleChangeTasksSelectField = (e) => {
        this.setState({statusField: e.target.value});
     }

    saveData = () => {
        let x = {};
        x.tasksName = this.state.nameField;
        x.description = this.state.descriptionField;
        x.statusId = 1; 
        fetch(URLGETLOCALHOST, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(x)
        });
        this.props.saveElement(x);
    }


    render() {
        
        const updateOrCreate = () => {

            if(this.state.task === undefined) {
                return  <React.Fragment>
                            <Form>
                                <Form.Field 
                                    control={Input}
                                    label={this.state.formInputFieldsConfig.nameField.lable}
                                    placeholder={this.state.formInputFieldsConfig.nameField.placeholder}
                                    onChange={this.handleChangeTasksName}
                                />
                                <Form.Field 
                                    control={TextArea}
                                    label={this.state.formInputFieldsConfig.descriptionField.lable}
                                    placeholder={this.state.formInputFieldsConfig.descriptionField.placeholder}
                                    onChange={this.handleChangeTasksDescriptionField}
                                    />
                                <Form.Field 
                                    control={Select}
                                    label={this.state.formInputFieldsConfig.selectedField.lable}
                                    placeholder={this.state.formInputFieldsConfig.selectedField.placeholder}
                                    options={this.state.statuses}
                                />  
                                <div class="field">
                                    <select className="ui search dropdown">
                                        <option></option>
                                    </select>
                                </div>
                            </Form>
                        </React.Fragment>                     
            }
            else {
                return <React.Fragment>            
                    <Form.Field 
                        control={Input}
                        label={this.state.formInputFieldsConfig.nameField.lable}
                        placeholder={this.state.formInputFieldsConfig.nameField.placeholder}
                        onChange={this.handleChangeTasksName}
                        value={this.props.editElement.tasksName}
                    />
                    <Form.Field 
                        control={TextArea}
                        label={this.state.formInputFieldsConfig.descriptionField.lable}
                        placeholder={this.state.formInputFieldsConfig.descriptionField.placeholder}
                        onChange={this.handleChangeTasksDescriptionField}
                        value={this.props.editElement.description}
                        />
                    <Form.Field 
                        control={Select}
                        label={this.state.formInputFieldsConfig.selectedField.lable}
                        placeholder={this.state.formInputFieldsConfig.selectedField.placeholder}
                        options={this.state.statuses}
                    />                       
                </React.Fragment>            
            }
        }
        

        
        return ( 
            <Grid container>
                <Grid.Column>
                    <Form>
                        {updateOrCreate()}
                        <Form.Button color="green" onClick={this.saveData}> Сохранить </Form.Button>
                        <Form.Button color="blue" onClick={this.props.closeFrom}> Закрыть </Form.Button>   
                    </Form>
                </Grid.Column>
            </Grid>
        );
    }
}
 
export default FormTab;