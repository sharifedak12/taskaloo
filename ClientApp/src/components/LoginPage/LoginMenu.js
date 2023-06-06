import React, { Component, Fragment } from 'react';
import { Link , NavLink } from 'react-router-dom';
import authService from '../../config/AuthorizeService';
import { ApplicationPaths } from '../../config/ApiAuthorizationConstants';

export class LoginMenu extends Component {
  constructor(props) {
    super(props);

    this.state = {
      isAuthenticated: false,
      userName: null
    };
  }

  componentDidMount() {
    this._subscription = authService.subscribe(() => this.populateState());
    this.populateState();
  }

  componentWillUnmount() {
    authService.unsubscribe(this._subscription);
  }

  async populateState() {
    const [isAuthenticated, user] = await Promise.all([authService.isAuthenticated(), authService.getUser()])
    this.setState({
      isAuthenticated,
      userName: user && user.name
    });
  }

  render() {
    const { isAuthenticated, userName } = this.state;
    if (!isAuthenticated) {
      const registerPath = `${ApplicationPaths.Register}`;
      const loginPath = `${ApplicationPaths.Login}`;
      return this.anonymousView(registerPath, loginPath);
    } else {
      const profilePath = `${ApplicationPaths.Profile}`;
      const logoutPath = `${ApplicationPaths.LogOut}`;
      const logoutState = { local: true };
      return this.authenticatedView(userName, profilePath, logoutPath, logoutState);
    }
  }

  authenticatedView(userName, profilePath, logoutPath, logoutState) {
    return (<Fragment>
      <li className="nav-link">
        <NavLink tag={Link} className="text-dark" to={profilePath}>Hello {userName}</NavLink>
      </li>
      <li className="nav-link">
        <NavLink replace tag={Link} className="text-dark" to={logoutPath} state={logoutState}>Logout</NavLink>
      </li>
    </Fragment>);
  }

  anonymousView(registerPath, loginPath) {
    return (<Fragment>
      <li className="nav-link">
        <NavLink tag={Link} className="text-dark" to={registerPath}>Register</NavLink>
      </li>
      <li className="nav-link">
        <NavLink tag={Link} className="text-dark" to={loginPath}>Login</NavLink>
      </li>
    </Fragment>);
  }
}
