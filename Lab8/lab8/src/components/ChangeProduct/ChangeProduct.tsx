import { message, Modal, Row, Space, Steps } from "antd";
import axios from "axios";
import { FC, useEffect, useState } from "react";
import {
  Form,
  Input,
  Button,
  Select,
  DatePicker,
  InputNumber,
  Card
} from 'antd';
import { Contractor } from "../../models/contractor/Contractor";
import { BASE_URL } from "../../config/url_config";
import { GenderType } from "../../models/contractor/GenderType";
import { BrowserRouter, useHistory, Link } from "react-router-dom";
import Title from "antd/lib/typography/Title";
import { Column } from "rc-table";
import { Product } from "../../models/product/Product";
import { Header } from "antd/lib/layout/layout";
import moment from "moment";

const { RangePicker } = DatePicker;

export const ChangeProduct = () => {

  let history: any = useHistory();

  const firstNameMaxLength: number = 50;
  const lastNameMaxLength: number = 50;
  const contactsMaxLength: number = 200;
  const techSkillsMaxLength: number = 200;
  const softSkillsMaxLength: number = 200;
  const experienceMaxLength: number = 300;
  const educationMaxLength: number = 300;

  const [currentProduct, setCurrentProduct] = useState<Product>();
  const [isModalVisible, setIsModalVisible] = useState(false);
  const [productForm] = Form.useForm<Product>();

  const onRegistration = () => {
    history.push("/");
  }

  useEffect(() => {
    const getUser = async (id: number) => {
      const response = await axios.get(
        BASE_URL + 'products/' + id.toString() //id.toString()
      )
      setCurrentProduct(response.data);
    }
    getUser(1);
  }, [])

  const showModal = () => {
    setIsModalVisible(true);
  };

  const handleOk = () => {
    setIsModalVisible(false);
    productForm.resetFields();
  };

  const handleCancel = () => {
    setIsModalVisible(false);
    productForm.resetFields();
  };

  const handleUpdate = async () => {

    if (currentProduct !== undefined && currentProduct !== null && currentProduct.id !== undefined)
    {
      const newProduct: Product = {
        id: currentProduct.id,
        price: productForm.getFieldValue(['product', 'price']),
        startDate: productForm.getFieldValue(['product', 'start-date']),
        endDate: productForm.getFieldValue(['product', 'end-date']),
        demoVersion: currentProduct.demoVersion,
        media: currentProduct.media,
        repository: currentProduct.repository,
        documentation: currentProduct.documentation
      }
      
      await axios.put(
        BASE_URL + 'products/1',
        newProduct
      ).then((data: any) => {
        console.log(data);
        setCurrentProduct(newProduct);
        message.success('Product updated successfully');
      }).catch((error: Error) => {
        console.log(error);
        console.log(error.message);
        message.error("Error during updating product")
      })
    }
    else {
      message.error("Can't update empty product!");
    }

    setIsModalVisible(false);
    productForm.resetFields();
  }

  return (
      <>
        <Card style={{width: 300}}>
          <p>Id - {currentProduct?.id}</p>
          <p>Price - {currentProduct?.price}</p>
          <p>Start date - {moment(currentProduct?.startDate.toLocaleString()).format("DD.MM.YYYY")}</p>
          <p>End date - {moment(currentProduct?.endDate.toLocaleString()).format("DD.MM.YYYY")}</p>
          <p>Demo - {currentProduct?.demoVersion}</p>
          <p>Media - {currentProduct?.media}</p>
          <p>Docs - {currentProduct?.documentation}</p>
          <p>Repo - {currentProduct?.repository}</p>
        </Card>
        <Button type="primary" onClick={showModal}>
          Change product data
        </Button>
        <Modal title="Change product data" visible={isModalVisible} onOk={productForm.submit} onCancel={handleCancel}>
          <Form form={productForm} name="product-form" onFinish={handleUpdate}>
            <Form.Item 
              name={[
                'product', 'price'
              ]}
              label="Price"
            >
              <InputNumber  
                defaultValue={currentProduct?.price}
              />
            </Form.Item>
            <Form.Item 
              name={[
                'product', 'start-date'
              ]}
              label="Start date"
              >
              <DatePicker defaultValue={moment(currentProduct?.startDate)} />
            </Form.Item>
            <Form.Item 
              name={[
                'product', 'end-date'
              ]}
              label="End date"
              >
              <DatePicker defaultValue={moment(currentProduct?.endDate)} />
            </Form.Item>
          </Form>
        </Modal>
      </>
    );
};
