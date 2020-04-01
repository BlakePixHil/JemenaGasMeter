import React, { Component } from "react";
import { View, AsyncStorage, Dimensions } from "react-native";
import { Button } from "react-native-elements";

export default class Options extends Component {
  constructor(props) {
    super(props);
    this.state = {
      buttonwidth: Math.round(Dimensions.get("window").width) - 30
    };
  }
  static navigationOptions = {
    headerLeft: () => null
  };
  render() {
    const { navigation } = this.props;
    return (
      <View
        style={{
          flex: 1,
          alignItems: "center",
          justifyContent: "start",
          flexDirection: "column"
        }}
      >
        <Button
          title="Pick up meters"
          onPress={() => {
            this.props.navigation.navigate("Home");
            AsyncStorage.clear();
          }}
          style={{ width: this.state.buttonwidth, height: 60 }}
        />
        <Button
          title="Change meter status"
          onPress={() => {
            this.props.navigation.navigate("Home");
            AsyncStorage.clear();
          }}
          style={{ width: this.state.buttonwidth, height: 60 }}
        />
        <Button
          title="View my meters"
          onPress={() => {
            this.props.navigation.navigate("Home");
            AsyncStorage.clear();
          }}
          style={{ width: this.state.buttonwidth, height: 60 }}
        />
        <Button
          title="Transfer meter ownership"
          onPress={() => {
            this.props.navigation.navigate("Home");
            AsyncStorage.clear();
          }}
          style={{ width: this.state.buttonwidth, height: 60 }}
        />
        <Button
          title="Logout"
          onPress={() => {
            this.props.navigation.navigate("Home");
            AsyncStorage.clear();
          }}
          style={{ width: this.state.buttonwidth, height: 60 }}
        />
      </View>
    );
  }
}
