import React from 'react';

import { AppProvider } from '@front-end/contexts';

const App = (props) => {
  return (
    <AppProvider initialValues={{}}>
      {props.children}
    </AppProvider>
  );
}

export default App;
