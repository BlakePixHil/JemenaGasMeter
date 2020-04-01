import { createAppContainer } from "react-navigation";
import { createStackNavigator } from "react-navigation-stack";
import Login from "./components/Login";
import Options from "./components/Options";
import React, { Component } from "react";

const RootStack = createStackNavigator(
  {
    Home: Login,
    Options: Options
  },
  {
    initialRouteName: "Home"
  }
);

const AppContainer = createAppContainer(RootStack);

export default class App extends Component {
  render() {
    return <AppContainer />;
  }
}
