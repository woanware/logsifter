# logsifter

I was inspired by reading the blog post here: https://unomaly.com/blog/its-in-the-anomalies/. It mentioned a tool for reducing log file data sets using Levenstein distance, with the resulting output being greatly reduced, thus allowing easier spotting of anomalies. The tool was only supplied in binary format so I wrote my own version. This is a C# rewrite of my initial golang version

## Example Reduction

```
Test file: syslog
Lines Before: 698
Line After: 49

Test File: dpkg.log
Lines Before: 26602
Line After: 34
```
