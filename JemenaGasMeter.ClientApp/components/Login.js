import React, { Component } from "react";
import {
  Text,
  Keyboard,
  ScrollView,
  AsyncStorage,
  Dimensions
} from "react-native";
import { Input, Button } from "react-native-elements";

export default class Login extends Component {
  constructor(props) {
    super(props);

    this.state = {
      username: "",
      password: "",
      errors: {
        username: "",
        password: ""
      },
      buttonwidth: Math.round(Dimensions.get("window").width) - 20
    };
  }
  validateForm() {
    if (
      this.state.errors.username == "" &&
      this.state.errors.password == "" &&
      this.state.username != "" &&
      this.state.password != ""
    ) {
      return true;
    } else {
      return false;
    }
  }
  handleChange = (field, value) => {
    let errors = this.state.errors;

    switch (field) {
      case "password":
        this.state.password = value;
        if (value.length == 0) {
          errors.password = "Password is required";
        } else if (value.length > 0 && value.length != 4) {
          errors.password = "Password must be 4 characters long";
        } else {
          errors.password = "";
        }
        break;
      case "username":
        this.state.username = value;
        if (value.length == 0) {
          errors.username = "Username is required";
        } else {
          errors.username = "";
        }
        break;
      default:
        this.setState({
          username: "",
          password: ""
        });
        break;
    }
    this.setState({ errors, [field]: value });
    this.validateForm();
  };
  _loadInitialState = async () => {
    var value = await AsyncStorage.getItem("user");
    if (value != null) {
      this.props.navigation.navigate("Options", {
        itemId: 86,
        otherParam: "anything you want here"
      });
    }
  };
  async onLogin() {
    try {
      let response = await fetch(
        "http://localhost:5000/api/user/" +
          this.state.username +
          "/" +
          this.state.password
      );
      let json = await response.json();
      this.usernameInput.clear();
      this.passwordInput.clear();
      Keyboard.dismiss();
      if (json) {
        AsyncStorage.setItem("user", this.state.username);
        this.state.username = "";
        this.state.password = "";
        await this.handleChange("", "");
        this.props.navigation.navigate("Options", {
          itemId: 86,
          otherParam: "anything you want here"
        });
      } else {
        this.state.username = "";
        this.state.password = "";
        await this.handleChange("", "");
        alert("Invalid username or password!!");
      }
    } catch (error) {
      console.log(error);
    }
  }
  render() {
    return (
      <ScrollView
        contentContainerStyle={{
          alignItems: "center",
          flex: 1,
          flexDirection: "column"
        }}
        keyboardShouldPersistTaps="handled"
      >
        <Text style={{ padding: 0, fontSize: 20, marginTop: 10 }}></Text>
        <Input
          ref={input => {
            this.usernameInput = input;
          }}
          placeholder="Enter your Payroll ID"
          onChangeText={username => {
            this.handleChange("username", username);
          }}
        />
        <Text
          style={{
            marginTop: 10,
            color: "red",
            marginLeft: 0
          }}
        >
          {this.state.errors.username}
        </Text>
        <Text></Text>
        <Input
          ref={input => {
            this.passwordInput = input;
          }}
          placeholder="Enter your 4 digit pin"
          keyboardType="numeric"
          onChangeText={password => {
            this.handleChange("password", password);
          }}
          secureTextEntry={true}
        />
        <Text
          style={{
            marginTop: 10,
            color: "red",
            marginLeft: 0
          }}
        >
          {this.state.errors.password}
        </Text>
        <Button
          title="Login"
          style={{
            marginTop: 30,
            overflow: "hidden"
          }}
          onPress={this.onLogin.bind(this)}
          disabled={!this.validateForm()}
          style={{ width: this.state.buttonwidth, height: 50, marginTop: 20 }}
        />
      </ScrollView>
    );
  }
}
