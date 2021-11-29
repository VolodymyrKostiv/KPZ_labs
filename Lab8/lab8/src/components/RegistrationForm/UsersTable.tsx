import { Button, message, Steps } from "antd";
import axios from "axios";
import { useState, useEffect } from "react";
import { Table, Tag } from 'antd';
import { Contractor } from "../../models/contractor/Contractor";
import { BASE_URL } from "../../config/url_config";
import { GenderType } from "../../models/contractor/GenderType";
import { useHistory } from "react-router-dom";
    
export const UsersTable = () => {

  const columns = [
    {
      title: 'Id',
      dataIndex: 'id',
      key: 'id',
    },
    {
      title: 'First name',
      dataIndex: 'firstName',
      key: 'firstName',
    },
    {
      title: 'Last name',
      dataIndex: 'lastName',
      key: 'lastName',
    },
    {
      title: 'Age',
      dataIndex: 'age',
      key: 'age',
    },
    {
      title: 'Gender',
      key: 'gender',
      dataIndex: 'gender',
      render: (gender: GenderType) => (
        <Tag color={gender === GenderType.Male ? "blue" : (gender === GenderType.Female ? "pink" : "green")} key={gender}>
          {GenderType[gender].toString()}
        </Tag>
      ),
    },
    {
      title: 'Contacts',
      dataIndex: 'contacts',
      key: 'contacts'
    },
  ];

  let history: any = useHistory();

  const [contractors, setContractors] = useState<Array<Contractor>>([]);
  const [visible, setVisible] = useState(false);
  const [confirmLoading, setConfirmLoading] = useState(false);

  useEffect(() => {
    const getTableData = async () => {
      const response = await axios.get(BASE_URL + 'contractors');
      setContractors(response.data);
    }
    getTableData();
  }, [])
  
  const handleDelete = async (id: number) => {
    console.log(BASE_URL + 'contractors/' + id)
    axios.delete(BASE_URL + 'contractors/' + id
    ).then(() => {
      message.success("User was successfully deleted!");
      setContractors(contractors.filter(item => item.id !== id));
    }).catch(() => {
      message.error("Error during deleting this user!");
    })
  } 

  const onRegistr = () => {
    history.push("/");
  }

  return (
    <>
      <Table 
        columns={columns} 
        dataSource={contractors} 
        bordered
        onRow={(record, rowIndex) => {
          return {
            onClick: event => { handleDelete(record.id) },
          };
        }}
        />
      <Button onClick={onRegistr} >
        Back to registration
      </Button>
    </>
  );
};