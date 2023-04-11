import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { tasks: [], loading: true };
  }

  componentDidMount() {
    this.populateTaskData();
  }

  static renderTasksTable(tasks) {
    return (
      <table className="table table-striped" aria-labelledby="tableLabel">
        <thead>
          <tr>
            <th>Date</th>
            <th>Temp. (C)</th>
            <th>Temp. (F)</th>
            <th>Summary</th>
          </tr>
        </thead>
        <tbody>
          {tasks.map(task =>
            <tr key={task.date}>
              <td>{task.date}</td>
              <td>{task.temperatureC}</td>
              <td>{task.temperatureF}</td>
              <td>{task.summary}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderTasksTable(this.state.tasks);

    return (
      <div>
        <h1 id="tableLabel">Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateTaskData() {
    const response = await fetch('tasks');
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
  }
}
