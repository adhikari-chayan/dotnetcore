RG.PYEXECUTE "
def publish(x):
    key = x['key']
    subKey = key.split(':')[1]
    value = execute('GET', f'Delayed-Value:{subKey}')
    execute('XADD', 'signalsStream', '*', key, value)
    execute('PUBLISH', 'signals', key)

cap = GB('KeysReader')
cap.foreach(publish)
cap.register(prefix='Delayed:*',
             mode='sync',
             eventTypes=['expired'],
             readValue=False)

"

def publish(x):
    key = x['key']
    execute('XADD', 'signalsStream', '*', key, key)
    execute('PUBLISH', 'signals', key)

GB('KeysReader')
.foreach(publish)
.register(prefix='Delayed:*',
             mode='sync',
             eventTypes=['expired'],
             readValue=False)