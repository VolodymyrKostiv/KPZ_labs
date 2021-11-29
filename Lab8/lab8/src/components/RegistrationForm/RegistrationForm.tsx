import { message, Row, Space, Steps } from "antd";
import axios from "axios";
import { FC, useState } from "react";
import {
  Form,
  Input,
  Button,
  Select,
  DatePicker,
  InputNumber
} from 'antd';
import { Contractor } from "../../models/contractor/Contractor";
import { BASE_URL } from "../../config/url_config";
import { GenderType } from "../../models/contractor/GenderType";
import { BrowserRouter, useHistory, Link } from "react-router-dom";
import Title from "antd/lib/typography/Title";
import { Column } from "rc-table";

export const RegistrationForm = () => {

  let history: any = useHistory();

  const ageMin: number = 18;
  const ageMax: number = 99;
  const firstNameMaxLength: number = 50;
  const lastNameMaxLength: number = 50;
  const contactsMaxLength: number = 200;
  const techSkillsMaxLength: number = 200;
  const softSkillsMaxLength: number = 200;
  const experienceMaxLength: number = 300;
  const educationMaxLength: number = 300;

  const [contractorForm] = Form.useForm();

  const onReset = () => {
    contractorForm.resetFields();
  }

  const onSubmit = async (event: any) => {

    event.preventDefault();

    const newContractor: Contractor = {
      id: 0,
      firstName: contractorForm.getFieldValue(['contractor', 'firstName']),
      lastName: contractorForm.getFieldValue(['contractor', 'lastName']),
      age: contractorForm.getFieldValue(['contractor', 'age']),
      gender: contractorForm.getFieldValue(['contractor', 'gender']),
      contacts: contractorForm.getFieldValue(['contractor', 'contacts']),
      techSkills: contractorForm.getFieldValue(['contractor', 'techSkills']),
      softSkills: contractorForm.getFieldValue(['contractor', 'softSkills']),
      experience: contractorForm.getFieldValue(['contractor', 'experience']),
      education: contractorForm.getFieldValue(['contractor', 'education']),
    };

    await axios.post(
      BASE_URL + 'contractors',
      newContractor
    ).then((res) => {
      message.success('User was created successfully!');
    }).catch((error: Error) => {
      console.log('Error during adding new user ' + newContractor);
      console.log(error);
      console.log(error.message);
      message.error('Error during adding new user!');
    }).finally(() => {
      contractorForm.resetFields();
    })
  }

  const onTable = () => {
    history.push("/allusers");
  }

  return (
    <>
      <Space  align="center">
        <Title level={2}>Extended registration</Title>
      </Space>
      <Form
        labelCol={{ span: 6 }}
        wrapperCol={{ span: 10 }}
        layout="horizontal"
        form={contractorForm}
        name="contractorRegistrationForm"
      >
        <Form.Item
          name={[
            'contractor', 'firstName'
          ]}
          label="First name"
          rules={[
            {
              required: true,
              message: 'Please, enter first name',
            }
          ]}>
          <Input maxLength={firstNameMaxLength} />
        </Form.Item>
        <Form.Item 
          name={[
            'contractor', 'lastName'
          ]}
          label="Last name"
          rules={[
            {
              required: true,
              message: 'Please, enter last name',
            }
          ]}>
          <Input maxLength={lastNameMaxLength}/>
        </Form.Item>

        <Form.Item 
          name={[
            'contractor', 'age'
          ]}
          label="Age"
          rules={[
            {
              required: true,
              message: 'Please, enter your age',
            }
          ]}>
          <InputNumber  
            min={ageMin}
            max={ageMax}
          />
        </Form.Item>

        <Form.Item 
          name={[
            'contractor', 'gender'
          ]}
          label="Gender"
          rules={[
            {
              required: true,
              message: 'Please, enter your gender',
            }
          ]}>
          <Select>
            <Select.Option value={GenderType.Male}>Male</Select.Option>
            <Select.Option value={GenderType.Female}>Female</Select.Option>
            <Select.Option value={GenderType.Il_2_Sturmovik}>Il-2 Sturmovik</Select.Option>
          </Select>
        </Form.Item>

        <Form.Item 
          label="Contacts"
          name={[
            'contractor', 'contacts'
          ]}>
          <Input.TextArea showCount maxLength={contactsMaxLength}/>
        </Form.Item>

        <Form.Item 
          label="Tech skills"
          name={[
            'contractor', 'techSkills'
          ]}>
          <Input.TextArea showCount maxLength={techSkillsMaxLength}/>
        </Form.Item>

        <Form.Item 
          label="Soft skills"
          name={[
            'contractor', 'softSkills'
          ]}>
          <Input.TextArea showCount maxLength={softSkillsMaxLength}/>
        </Form.Item>

        <Form.Item 
          label="Experience"
          name={[
            'contractor', 'experience'
          ]}>
          <Input.TextArea showCount maxLength={experienceMaxLength}/>
        </Form.Item>

        <Form.Item 
          label="Education"
          name={[
            'contractor', 'education'
          ]}>
          <Input.TextArea showCount maxLength={educationMaxLength}/>
        </Form.Item>

        <Row >
          <Button onClick={onTable} >
            Users table
          </Button>

          <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
            <Button onClick={onReset} type="default">
              Reset
            </Button>
          </Form.Item>

          <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
            <Button onClick={onSubmit} type="primary">
              Submit
            </Button>
          </Form.Item>
        </Row>
      </Form>
    </>
  );
};
