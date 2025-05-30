---
title: Logging
sidebar_position: 4
---

Kadense workflow logs out the status of each record as it passes through the system.

```text
2025-05-12 14:06:28.730 info: Kadense.Malleable.Workflow.Apis.MalleableWorkflowIngressApi[0] api://TestApi TestConditional 99e98c0e-fd62-4dd2-8615-ba27f83c622d h/pmqkAtsTksLO3b7Qv1ZUuiAhDASWE1ffEGcEpn0iE= Xbn5CzaNrjbJrpkYCrFajd00sj3ZhbDAKnFgEuPlzZE= Xbn5CzaNrjbJrpkYCrFajd00sj3ZhbDAKnFgEuPlzZE= obImRIblbS8qgmdopULGENzQsKnBYnlPDsnM5TLSGhM= 
2025-05-12 14:06:28.735 info: Kadense.Malleable.Workflow.MalleableWorkflowQueueProcessor[0] TestConditional TestStep 99e98c0e-fd62-4dd2-8615-ba27f83c622d hynL1fyJk5jCwg//wZ4mhCZ0+6Q6rS81WEkr2IzzMIo= E87fDC1w6c2Ml/rj7QfetWGCOJ3yDo7pgmUsYxGvW8o= dXchVeH4o3eC8t4oqhMqgTR4mUUmVur7Cwp7IrMteMc= coSchQIHfdffYi31cR8Cfs8tDu5EaVDFZmBDdDli9f0=
2025-05-12 14:06:28.737 info: Kadense.Malleable.Workflow.MalleableWorkflowQueueProcessor[0] TestStep WriteApi 99e98c0e-fd62-4dd2-8615-ba27f83c622d dzc59yk1ssunbKm8JccCvgg7apVQjN5U5yjP/oFR13s= qv2+pWBau60pVZS2uaUxQj+DxJwtukOSdXkL3r03hGg= ghFHzpamDLvmyL2KhIdwZxaSFMloGYaQwxipYMvxkfA= /EbDgm0zg4xikHpyDXiHzyDwMxhq7x4JNCU6vS/n8a0=
2025-05-12 14:06:28.748 info: Kadense.Malleable.Workflow.MalleableWorkflowQueueProcessor[0] WriteApi {abandoned} 99e98c0e-fd62-4dd2-8615-ba27f83c622d Go7lzh4J/lCTi59dys7O2RmEn8lpoA+hGJgD1rsWhEE= FoP4Wgq07VY81cshsKwzQxd3GuFl+tv09TIA8zgyEQM= sN4KMWRSU9nCGW7dBeFScKYCVeSmdZNrYltaz9V5ra8= CwZhYMtGPoBc1MDO9qEIpmIcMVmHUduhO4ZeyWqORA0=
```

The looking at a simple message:

```text
2025-05-12 14:06:28.737 info: Kadense.Malleable.Workflow.MalleableWorkflowQueueProcessor[0] TestStep WriteApi 99e98c0e-fd62-4dd2-8615-ba27f83c622d dzc59yk1ssunbKm8JccCvgg7apVQjN5U5yjP/oFR13s= qv2+pWBau60pVZS2uaUxQj+DxJwtukOSdXkL3r03hGg= ghFHzpamDLvmyL2KhIdwZxaSFMloGYaQwxipYMvxkfA= /EbDgm0zg4xikHpyDXiHzyDwMxhq7x4JNCU6vS/n8a0=
```

This was:
* Processed on 12th May 2025 at 14:06:28
* an information message
* generated by the class: Kadense.Malleable.Workflow.MalleableWorkflowQueueProcessor
* completed by the step called "TestStep"
* being directed to the "WriteApi" step
* part of the lineage 99e98c0e-fd62-4dd2-8615-ba27f83c622d
* raw message is signed with a value of dzc59yk1ssunbKm8JccCvgg7apVQjN5U5yjP/oFR13s=
* lineage is signed with a value of qv2+pWBau60pVZS2uaUxQj+DxJwtukOSdXkL3r03hGg=
* process is signed with a value of ghFHzpamDLvmyL2KhIdwZxaSFMloGYaQwxipYMvxkfA=
* combination is signed with a value of /EbDgm0zg4xikHpyDXiHzyDwMxhq7x4JNCU6vS/n8a0=

When a message reaches the end of the workflow the destination will show as:

```text
{abandoned}
```